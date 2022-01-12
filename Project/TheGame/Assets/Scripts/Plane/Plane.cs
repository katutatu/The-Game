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
    bool IsDead { get; }
    int Stock { get; }
}

/// <summary>機体クラス</summary>
public class Plane : MonoBehaviour, IPlaneCockpit
{
    /// <summary>死亡しているか</summary>
    public bool IsDead { get { return Stock <= 0; } }

    /// <summary>残機</summary>
    public int Stock { get; private set; }

    /// <summary>移動速度</summary>
    public float MoveSpeed { get; private set; }


    /// <summary>被ダメージ時イベント 引数: ダメージ後の残機数</summary>
    public System.Action<int> OnDamaged;


    public void Setup(PlaneData planeData)
    {
        Stock = planeData.stock;
        MoveSpeed = planeData.move_speed;
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
