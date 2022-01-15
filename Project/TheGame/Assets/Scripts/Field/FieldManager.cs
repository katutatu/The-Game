using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : SingletonMonoBehaviour<FieldManager>
{
    private Dictionary<string, FieldObjectBase> _fieldObjects = new Dictionary<string, FieldObjectBase>();

    private FieldObjectFactory _fieldObjectfactry;

    public FieldObjectBase CreateFieldObject(string objectID, string assetName)
    {
        if (_fieldObjects.ContainsKey(objectID))
        {
            //すでにある場合は作りません！！！！！！
            return null;
        }

        var fieldObject = _fieldObjectfactry.CreateFieldObject(assetName);
        Debug.Assert(fieldObject);
        _fieldObjects.Add(objectID, fieldObject);
        return fieldObject;
    }

    public FieldObjectBase GetFieldObject(string objectID)
    {
        Debug.Assert(_fieldObjects[objectID]);
        return _fieldObjects[objectID];
    }
    
    public void Setup(FieldObjectFactory factry)
    {
        Debug.Assert(factry);
        _fieldObjectfactry = factry;
    }

    public void CreateAndSetupStageFieldObjects()
    {
        var spawnData = FindObjectOfType<FieldObjectSpawnInfo>();
        foreach (var data in spawnData.SpawnList)
        {
            var objectData = CreateFieldObject(data.uniqueID, data.objectTypeID);
            if (objectData)
            {
                objectData.transform.position = data.spawnPos;
            }
        }
    }
}
