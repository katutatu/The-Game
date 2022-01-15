using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObjectSpawnInfo : MonoBehaviour
{
    /**これつけないと構造体がUnity上に出ない罠*/
    [System.Serializable]
    public struct ObjectSpawnInfo
    {
        /** オブジェクト種類のID*/
        public string objectTypeID;
        /** 固有のID*/
        public string uniqueID;
        /** すぽーんざひょー */
        public Vector3 spawnPos;
    }

    public ObjectSpawnInfo[] SpawnList;
}
