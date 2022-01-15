using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FieldObjectData : DataBase
{
    /// <summary>アセット名</summary>
    public string asset_name;

    /// <summary>移動速度</summary>
    public float move_speed;

    /// <summary>回転速度</summary>
    public Vector3 rotate_speed;

    /// <summary>撃破時のスコア</summary>
    public int score;
}
