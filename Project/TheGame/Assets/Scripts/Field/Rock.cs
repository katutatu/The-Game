using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : FieldObjectBase
{
    void Start()
    {

    }

    void Update()
    {
        Transform _transform = this.transform;

        Vector3 _rotateSpeed = new Vector3(0.0f, 0.01f, 0.5f);
        _transform.Rotate(_rotateSpeed);

        Vector3 _position = _transform.position;

        var target = GameObject.Find("Main Camera").transform;
        var diff = target.position - this.transform.position;
        diff.Normalize();

        const float moveSpeed = 0.2f;

        var velocity = diff * moveSpeed;
        _position += velocity * Time.deltaTime;
        _position.z -= moveSpeed;
        this.transform.position = _position;

        if (this.transform.position.z < -10.0f)
        {
            Destroy(this);
        }

    }
}
