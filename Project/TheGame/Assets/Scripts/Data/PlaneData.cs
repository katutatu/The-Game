using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlaneData : DataBase
{
    /// <summary>アセット名</summary>
    public string asset_name;

    /// <summary>残機(敵の場合はHP？)</summary>
    public int stock;

    /// <summary>移動速度</summary>
    public float move_speed;

    /// <summary>武器ID</summary>
    public string weapon_id;

    /// <summary>撃破時のスコア</summary>
    public int score;
}
