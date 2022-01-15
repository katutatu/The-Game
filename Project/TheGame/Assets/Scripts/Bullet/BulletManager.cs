using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletShootSystem
{
    void Shoot(BulletData bulletData, TeamTypes teamType, Vector3 position, Vector3 direction);
}

public class BulletManager : IBulletShootSystem
{
    private List<Bullet> _bullets = new List<Bullet>();


    public void Shoot(BulletData bulletData, TeamTypes teamType, Vector3 position, Vector3 direction)
    {
        var b = GetOrCreateBullet(bulletData);
        b.Reset(teamType, position, direction);
    }

    public Bullet GetOrCreateBullet(BulletData bulletData)
    {
        var bullet = (Bullet)null;

        foreach (var b in _bullets)
        {
            if (b.IsActive) { continue; }
            if (b.DataId != bulletData.id) { continue; }

            bullet = b;
            break;
        }

        if (bullet == null)
        {
            bullet = CreateBullet(bulletData);
        }

        return bullet;
    }

    public Bullet CreateBullet(BulletData bulletData)
    {
        var bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere).AddComponent<Bullet>();
        bullet.Setup(bulletData);
        _bullets.Add(bullet);
        return bullet;
    }

    public void Tick()
    {
        foreach (var bullet in _bullets)
        {
            bullet.Tick();
        }
    }
}
