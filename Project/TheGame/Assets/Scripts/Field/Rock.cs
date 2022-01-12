using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Transform _transform = this.transform;

        Vector3 _rotateSpeed = new Vector3(1.0f, 0.01f, 0.5f);
        _transform.Rotate(_rotateSpeed);

		Vector3 _pos = _transform.position;
		//床移動のスピード
		const float _moveSpeed = 0.1f;
		_pos.z -= _moveSpeed;
		_transform.position = _pos;
	}
}
