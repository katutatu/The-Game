using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Reset(Vector3 position, Vector3 direction)
    {
        transform.position = position;
        transform.forward = direction.normalized;
        transform.localScale = Vector3.one * 0.25f;
    }

    public void Tick()
    {
        transform.position += transform.forward * 30.0f * Time.deltaTime;
    }
}
