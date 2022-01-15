using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneFactory : MonoBehaviour
{
    [SerializeField]
    private Plane _planeRigPrefab = null;
    [SerializeField]
    private GameObject[] _planeModelPrefabs = null;


    public Plane CreatePlane(string assetName)
    {
        var planeRigPrefab = _planeRigPrefab;
        var planeModelPrefab = GetPlaneModelPrefab(assetName);

        var planeRig = Object.Instantiate(planeRigPrefab);
        var planeModel = Object.Instantiate(planeModelPrefab);

        planeModel.transform.SetParent(planeRig.transform);

        return planeRig;
    }

    private GameObject GetPlaneModelPrefab(string assetName)
    {
        foreach (var planeModelPrefab in _planeModelPrefabs)
        {
            if (planeModelPrefab.name == assetName)
            {
                return planeModelPrefab;
            }
        }
        return null;
    }
}
