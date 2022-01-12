using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneData
{
    /// <summary>データID</summary>
    public string id;

    /// <summary>残機(敵の場合はHP？)</summary>
    public int stock;

    /// <summary>移動速度</summary>
    public float move_speed;

    /// <summary>弾発射間隔</summary>
    public float bullet_shoot_interval;
}
