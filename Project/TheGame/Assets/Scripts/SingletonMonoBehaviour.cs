using System;
using UnityEngine;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;


    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                DontDestroyOnLoad(_instance.gameObject);
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(this);
            return;
        }

        _instance = this as T;
        DontDestroyOnLoad(_instance.gameObject);
    }
}
