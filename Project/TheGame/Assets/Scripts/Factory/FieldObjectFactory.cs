using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObjectFactory : MonoBehaviour
{
    /**これつけないと構造体がUnity上に出ない罠*/
    [System.Serializable]
    public struct RigPrefabData
    {
        /** オブジェクト種類のID*/
        public string objectTypeID;
        /** プレハブ */
        public FieldObjectBase RigPrefab;
    }

    public RigPrefabData[] FieldObjectRigPrefabs;

    public FieldObjectBase CreateFieldObject(string objectTypeID)
    {
        foreach (var Prefab in FieldObjectRigPrefabs)
        {
            if (Prefab.objectTypeID.Equals(objectTypeID)) 
            {
                var fieldObjectRig = Object.Instantiate(Prefab.RigPrefab);
                return fieldObjectRig;
            } 
        }

        Debug.Assert(false);
        return null;
    }
}
