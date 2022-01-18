using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField]
    private Bullet[] _bulletPrefabs = null;


    public Bullet CreateBullet(string assetName)
    {
        var bulletPrefab = GetBulletPrefab(assetName);
        return Object.Instantiate(bulletPrefab);
    }

    private Bullet GetBulletPrefab(string assetName)
    {
        foreach (var bulletPrefab in _bulletPrefabs)
        {
            if (bulletPrefab.name == assetName)
            {
                return bulletPrefab;
            }
        }
        return null;
    }
}
