using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBulletShootSystem
{
    void Shoot(string id, Vector3 position, Vector3 direction);
}

public class BulletManager : IBulletShootSystem
{
    private List<Bullet> _bullets = new List<Bullet>();


    public void Shoot(string id, Vector3 position, Vector3 direction)
    {
        var b = CreateBullet();
        b.Reset(position, direction);
    }

    public Bullet CreateBullet()
    {
        var bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere).AddComponent<Bullet>();
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
