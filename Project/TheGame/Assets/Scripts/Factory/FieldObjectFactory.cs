using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldObjectFactory : MonoBehaviour
{
    [SerializeField]
    private FieldObjectBase _fieldObjectRigPrefab = null;
    [SerializeField]
    private GameObject[] _fieldObjectModelPrefabs = null;


    public FieldObjectBase CreateFieldObject(string assetName)
    {
        var fieldObjectRigPrefab = _fieldObjectRigPrefab;
        //var fieldObjectModelPrefab = GetFieldObjectModelPrefab(assetName);

        var fieldObjectRig = Object.Instantiate(fieldObjectRigPrefab);
        //var fieldObjectModel = Object.Instantiate(fieldObjectModelPrefab);

        //fieldObjectModel.transform.SetParent(fieldObjectRig.transform);

        return fieldObjectRig;
    }

    private GameObject GetFieldObjectModelPrefab(string assetName)
    {
        foreach (var fieldObjectModelPrefab in _fieldObjectModelPrefabs)
        {
            if (fieldObjectModelPrefab.name == assetName)
            {
                return fieldObjectModelPrefab;
            }
        }
        return null;
    }
}
