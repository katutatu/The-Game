using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObjectFactory : MonoBehaviour
{
    /**������Ȃ��ƍ\���̂�Unity��ɏo�Ȃ��*/
    [System.Serializable]
    public struct RigPrefabData
    {
        /** �I�u�W�F�N�g��ނ�ID*/
        public string objectTypeID;
        /** �v���n�u */
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
