using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterData : SingletonMonoBehaviour<MasterData>
{
    [SerializeField]
    private PlaneDataListSO _planeDataListSO = null;
    [SerializeField]
    private BulletDataListSO _bulletDataListSO = null;
    [SerializeField]
    private WeaponDataListSO _weaopnDataListSO = null;


    public PlaneData FindPlaneData(string id)
    {
        return _planeDataListSO?.Find(id);
    }

    public BulletData FindBulletData(string id)
    {
        return _bulletDataListSO?.Find(id);
    }

    public WeaponData FindWeaponData(string id)
    {
        return _weaopnDataListSO?.Find(id);
    }
}
