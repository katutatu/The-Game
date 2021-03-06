using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>機体操作インターフェース</summary>
public interface IPlaneCockpit : IPlaneReadOnly
{
    void Shoot(Vector3 vec);
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

public enum DeadCause
{
    None,
    Shoot,
    Other,
}

/// <summary>機体クラス</summary>
public class Plane : MonoBehaviour, IPlaneCockpit
{
    [SerializeField]
    private Weapon _weapon = null;


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
    public Vector3 Position { get { return transform.position; } }

    /// <summary>移動速度</summary>
    public float MoveSpeed { get; private set; }

    /// <summary>撃破時のスコア</summary>
    public int Score { get; private set; }

    /// <summary>ゴールに当たったか</summary>
    public bool IsHitGoal { get; private set; } = false;


    /// <summary>被ダメージ時イベント 引数: ダメージ後の残機数</summary>
    public System.Action<int> OnDamaged;
    /// <summary>死亡時イベント 引数: 死んだ起因</summary>
    public System.Action<DeadCause> OnDied;


    /// <summary>軌跡エフェクト</summary>
    private IEffect _trailEffect;


    public void Setup(PlaneData planeData, IBulletShootSystem bulletShootSystem, bool isPlayerPlane)
    {
        IsPlayerPlane = isPlayerPlane;
        SetTeam(isPlayerPlane ? TeamTypes.Player : TeamTypes.Enemy); // 味方のような概念はないのでとりあえずこれで良いはず
        Stock = planeData.stock;
        MoveSpeed = planeData.move_speed;
        Score = planeData.score;

        _weapon.Setup(MasterData.Instance.FindWeaponData(planeData.weapon_id), bulletShootSystem, TeamType);

        _trailEffect = EffectManager.Instance.GetEffect(EffectNames.PlaneTrail);
        _trailEffect.Play(transform);

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

    public void ReceiveDamage(DeadCause deadCause)
    {
        if (IsDead) { return; }

        Stock--;
        OnDamaged?.Invoke(Stock);

        if (IsDead)
        {
            Hide();
            OnDied?.Invoke(deadCause);
        }
    }

    public void Shoot(Vector3 vec)
    {
        if (IsDead) { return; }

        _weapon.Shoot(transform.position, vec);
    }

    public void Move(Vector3 vec)
    {
        if (IsDead) { return; }

        // くそ適当
        var move = vec.normalized * MoveSpeed * Time.deltaTime;
        var pos = transform.position;
        pos += move;

        float playerMovableSpaceX = 13.0f;
        float playerMovableSpaceY = 9.0f;
        if(pos.x < -playerMovableSpaceX)
        {
            pos.x = -playerMovableSpaceX;
        }
        
        if(pos.x > playerMovableSpaceX)
        {
            pos.x = playerMovableSpaceX;
        }

        if (pos.y < 0.0f)
        {
            pos.y = 0.0f;
        }

        //ゴールに当たった場合は上へ飛んでいくのでこの判定は無視
        if (!IsHitGoal)
        {
            if (pos.y > playerMovableSpaceY)
            {
                pos.y = playerMovableSpaceY;
            }
        }

        transform.position = pos;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            ReceiveDamage(DeadCause.Shoot);
            bullet.SetActive(false);
        }

        if (collider.gameObject.TryGetComponent<Rock>(out var rock))
        {
            ReceiveDamage(DeadCause.Other);
        }

        if (collider.gameObject.TryGetComponent<Gate>(out var gate))
        {
            if (IsPlayerPlane)
            {            
                //ゴールに当たった
                IsHitGoal = true;
            }
        }
    }
}
