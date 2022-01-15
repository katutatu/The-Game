using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : FieldObjectBase
{
    public float lifetime = 5.0f;
    private Vector3 velocity;
    private Transform target;
    private float period = 3.0f;

    void Start()
    {
        Destroy(this.gameObject, lifetime);
        target = GameObject.Find("Main Camera").transform;
    }

    void Update()
    {
        Transform _transform = this.transform;

        Vector3 _rotateSpeed = new Vector3(0.0f, 0.01f, 0.5f);
        _transform.Rotate(_rotateSpeed);

        Vector3 _position = _transform.position;
        //岩移動のスピード
        const float _moveSpeed = 0.1f;
        //_transform.position = _pos;

        var acceleration = Vector3.zero;

        var diff = target.position - _position;
        acceleration += (diff - velocity * period) * 2f
                    / (period * period);
        period -= Time.deltaTime;
        if (period < 0f)
        {
            return;
        }
        if (acceleration.magnitude > 100f)
        {
            acceleration = acceleration.normalized * 100f;
        }

        velocity += acceleration * Time.deltaTime;
        _position += velocity * Time.deltaTime;
        _position.z -= _moveSpeed;
        this.transform.position = _position;
    }
}
