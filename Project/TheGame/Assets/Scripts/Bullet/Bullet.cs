using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public TeamTypes TeamType { get; private set; }


    public void Reset(TeamTypes teamType, Vector3 position, Vector3 direction)
    {
        SetTeam(teamType);
        transform.position = position;
        transform.forward = direction.normalized;
        transform.localScale = Vector3.one * 0.25f;
    }

    public void Tick()
    {
        transform.position += transform.forward * 30.0f * Time.deltaTime;
    }

    public void SetTeam(TeamTypes teamType)
    {
        TeamType = teamType;
        gameObject.SetLayerRecursively(TeamType == TeamTypes.Player ? Layer.PlayerBullet : Layer.EnemyBullet);
    }
}
