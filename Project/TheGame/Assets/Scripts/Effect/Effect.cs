using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEffect
{
    void Play(Vector3 position);
    void Play(Transform parent);
}

public class Effect : MonoBehaviour, IEffect
{
    public bool IsActive { get { return gameObject.activeInHierarchy; } }


    private Transform _parent;
    private ParticleSystem _particle;


    public void Setup()
    {
        _particle = GetComponentInChildren<ParticleSystem>();
    }

    public void Tick()
    {
        if (_parent != null)
        {
            transform.position = _parent.transform.position;
        }
    }

    public void Play(Vector3 position)
    {
        if (_particle != null)
        {
            gameObject.SetActive(true);
            _particle.transform.position = position;
            _particle.Play(withChildren: true);
        }
    }

    public void Play(Transform parent)
    {
        _parent = parent;
        Play(parent.transform.position);
    }
}
