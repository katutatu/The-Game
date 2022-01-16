using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private TeamTypes _teamType;
    private BulletData _bulletData;
    private IBulletShootSystem _shootSystem;
    private float _shootInterval;

    private float _shootIntervalCount;


    public void Setup(WeaponData weaponData, IBulletShootSystem shootSystem, TeamTypes teamType)
    {
        _teamType = teamType;
        _bulletData = MasterData.Instance.FindBulletData(weaponData.bullet_id);
        _shootSystem = shootSystem;
        _shootInterval = weaponData.shoot_interval;

        _shootIntervalCount = 0.0f;
    }

    public void Shoot(Vector3 pos, Vector3 vec)
    {
        _shootIntervalCount += Time.deltaTime;
        if (_shootIntervalCount >= _shootInterval)
        {
            _shootIntervalCount = 0.0f;
            _shootSystem.Shoot(_bulletData, _teamType, pos, vec);
        }
    }
}
