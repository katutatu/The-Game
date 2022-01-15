using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>機体操作インターフェース</summary>
public interface IPlaneCockpit : IPlaneReadOnly
{
    void Shoot();
    void Move(Vector3 vec);
}

/// <summary>機体状態取得専用インターフェース</summary>
public interface IPlaneReadOnly
{
    bool IsActive { get; }
    bool IsDead { get; }
    int Stock { get; }
    Vector3 Position { get; }
}

public enum TeamTypes
{
    None,
    Player,
    Enemy,
}

/// <summary>機体クラス</summary>
public class Plane : MonoBehaviour, IPlaneCockpit
{
    /// <summary>所属陣営</summary>
    public TeamTypes TeamType { get; private set; }

    /// <summary>自機か</summary>
    public bool IsPlayerPlane { get; private set; }

    /// <summary>アクティブか</summary>
    public bool IsActive { get { return IsSpawned && !IsDead; } }

    /// <summary>スポーン済みか</summary>
    public bool IsSpawned { get; private set; }

    /// <summary>死亡しているか</summary>
    public bool IsDead { get { return Stock <= 0; } }

    /// <summary>残機</summary>
    public int Stock { get; private set; }

    /// <summary>座標</summary>
    public Vector3 Position { get; private set; }

    /// <summary>移動速度</summary>
    public float MoveSpeed { get; private set; }

    /// <summary>弾発射間隔</summary>
    public float BulletShootInterval { get; private set; }

    /// <summary>撃破時のスコア</summary>
    public int Score { get; private set; }


    /// <summary>被ダメージ時イベント 引数: ダメージ後の残機数</summary>
    public System.Action<int> OnDamaged;
    /// <summary>死亡時イベント</summary>
    public System.Action OnDied;


    private float _bulletShootIntervalCount;
    /// <summary>弾射撃インターフェース</summary>
    private IBulletShootSystem _bulletShootSystem;


    public void Setup(PlaneData planeData, IBulletShootSystem bulletShootSystem, bool isPlayerPlane)
    {
        IsPlayerPlane = isPlayerPlane;
        SetTeam(isPlayerPlane ? TeamTypes.Player : TeamTypes.Enemy); // 味方のような概念はないのでとりあえずこれで良いはず
        Stock = planeData.stock;
        BulletShootInterval = planeData.bullet_shoot_interval;
        MoveSpeed = planeData.move_speed;
        Score = planeData.score;

        _bulletShootSystem = bulletShootSystem;

        Hide();
    }

    public void Tick()
    {
        // Com機 && 未スポーン && 死亡していない なら移動
        if (!IsPlayerPlane && !IsSpawned && !IsDead)
        {
            transform.position += Vector3.back * BattleFixedParams.BattleObjectScrollSpeed * Time.deltaTime;

            // 一定距離より近くなったらスポーン
            if (transform.position.z <= BattleFixedParams.SpawnDistanceZ)
            {
                Spawn();
            }
        }
    }

    public void Spawn()
    {
        Debug.Assert(!IsSpawned);
        IsSpawned = true;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        IsSpawned = false;
        gameObject.SetActive(false);
    }

    public void SetTeam(TeamTypes teamType)
    {
        TeamType = teamType;
        gameObject.SetLayerRecursively(TeamType == TeamTypes.Player ? Layer.PlayerPlane : Layer.EnemyPlane);
    }

    public void ReceiveDamage()
    {
        if (IsDead) { return; }

        Stock--;
        OnDamaged?.Invoke(Stock);

        if (IsDead)
        {
            Hide();
            OnDied?.Invoke();
        }
    }

    public void Shoot()
    {
        if (IsDead) { return; }

        _bulletShootIntervalCount += Time.deltaTime;
        if (_bulletShootIntervalCount >= BulletShootInterval)
        {
            _bulletShootIntervalCount = 0.0f;
            _bulletShootSystem.Shoot(MasterData.Instance.FindBulletData("BULLET_DATA_0001"), TeamType, transform.position, transform.forward);
        }
    }

    public void Move(Vector3 vec)
    {
        if (IsDead) { return; }

        // くそ適当
        var move = vec.normalized * MoveSpeed * Time.deltaTime;
        transform.position += move;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            ReceiveDamage();
            bullet.SetActive(false);
        }
    }
}
