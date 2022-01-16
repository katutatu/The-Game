using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager 
{
    public Dictionary<string, FieldObjectBase> _fieldObjects = new Dictionary<string, FieldObjectBase>();

    public FieldObjectFactory _fieldObjectfactry;

    public FieldObjectBase CreateFieldObject(string uniqueID, string objectTypeID)
    {
        var fieldObject = _fieldObjectfactry.CreateFieldObject(objectTypeID);
        Debug.Assert(fieldObject);
        _fieldObjects.Add(uniqueID, fieldObject);
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
        var spawnData = GameObject.FindObjectOfType<FieldObjectSpawnInfo>();
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
