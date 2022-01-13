using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameUtility
{
    public static void SetLayerRecursively(this GameObject gameObject, int layer)
    {
        gameObject.layer = layer;
        for (var i = 0; i < gameObject.transform.childCount; i++)
        {
            SetLayerRecursively(gameObject.transform.GetChild(i).gameObject, layer);
        }
    }
}
