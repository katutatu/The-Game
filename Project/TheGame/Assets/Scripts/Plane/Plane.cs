using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>機体操作インターフェース</summary>
public interface IPlaneCockpit : IPlaneReadOnly
{
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

/// <summary>機体クラス</summary>
public class Plane : MonoBehaviour, IPlaneCockpit
{
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


    /// <summary>被ダメージ時イベント 引数: ダメージ後の残機数</summary>
    public System.Action<int> OnDamaged;


    public void Setup(PlaneData planeData, bool isPlayerPlane)
    {
        IsPlayerPlane = isPlayerPlane;
        Stock = planeData.stock;
        MoveSpeed = planeData.move_speed;

        gameObject.SetActive(false);
    }

    public void Tick()
    {
        // Com機が未スポーンなら移動
        if (!IsPlayerPlane && !IsSpawned)
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

    public void ReceiveDamage()
    {
        if (IsDead) { return; }

        Stock--;
        OnDamaged?.Invoke(Stock);
    }

    public void Move(Vector3 vec)
    {
        if (IsDead) { return; }

        // くそ適当
        var move = vec.normalized * MoveSpeed * Time.deltaTime;
        transform.position += move;
    }
}
