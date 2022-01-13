using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Layer
{
    public static readonly int PlayerPlane = LayerMask.NameToLayer("PlayerPlane");
    public static readonly int EnemyPlane = LayerMask.NameToLayer("EnemyPlane");
    public static readonly int PlayerBullet = LayerMask.NameToLayer("PlayerBullet");
    public static readonly int EnemyBullet = LayerMask.NameToLayer("EnemyBullet");
}
