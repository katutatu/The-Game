using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    void Play(Vector3 position);
}

public class Effect : MonoBehaviour, IEffect
{
    public bool IsActive { get { return gameObject.activeInHierarchy; } }


    private ParticleSystem _particle;


    public void Setup()
    {
        _particle = GetComponentInChildren<ParticleSystem>();
    }

    public void Play(Vector3 position)
    {
        if (_particle != null)
        {
            _particle.transform.position = position;
            _particle.Play(withChildren: true);
        }
    }
}
