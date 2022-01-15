using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string DataId { get; private set; }
    public bool IsActive { get; private set; }
    public TeamTypes TeamType { get; private set; }
    public float MoveSpeed { get; private set; }


    public void Setup(BulletData bulletData)
    {
        DataId = bulletData.id;
        MoveSpeed = bulletData.move_speed;
    }

    public void Reset(TeamTypes teamType, Vector3 position, Vector3 direction)
    {
        SetActive(true);
        SetTeam(teamType);
        transform.position = position;
        transform.forward = direction.normalized;
        transform.localScale = Vector3.one * 0.25f;
    }

    public void Tick()
    {
        if (IsActive)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }

        if (transform.position.z <= -10.0f || transform.position.z >= 50.0f)
        {
            SetActive(false);
        }
    }

    public void SetActive(bool isActive)
    {
        IsActive = isActive;
        gameObject.SetActive(isActive);
    }

    public void SetTeam(TeamTypes teamType)
    {
        TeamType = teamType;
        gameObject.SetLayerRecursively(TeamType == TeamTypes.Player ? Layer.PlayerBullet : Layer.EnemyBullet);
    }
}
