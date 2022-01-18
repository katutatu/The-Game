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

        var _target = GameObject.Find("Main Camera").transform;
        var _diff = _target.position - this.transform.position;
        _diff.Normalize();

        const float moveSpeed = 0.2f;

        var _velocity = _diff * moveSpeed;
        var _moveVec = _velocity * Time.deltaTime;
        _moveVec.z = -moveSpeed;
        _position += _moveVec;
        this.transform.position = _position;

        if (this.transform.position.z < -10.0f)
        {
            Destroy(this);
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.TryGetComponent<Bullet>(out var bullet))
        {
            bullet.SetActive(false);
            gameObject.SetActive(false);
            var explEffect = EffectManager.Instance.GetEffect(EffectNames.RockSpark);
            explEffect.Play(transform.position);
        }
    }
}
