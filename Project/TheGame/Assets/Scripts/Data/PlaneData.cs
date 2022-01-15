using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaneData : DataBase
{
    /// <summary>残機(敵の場合はHP？)</summary>
    public int stock;

    /// <summary>移動速度</summary>
    public float move_speed;

    /// <summary>弾発射間隔</summary>
    public float bullet_shoot_interval;

    /// <summary>撃破時のスコア</summary>
    public int score;
}
