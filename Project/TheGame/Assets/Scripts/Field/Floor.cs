using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
		Transform _transform = this.transform;
		Vector3 _pos = _transform.position;
		_pos.z -= 0.02f;

		if ( _pos.z <= -100.0f )
		{
			_pos.z = 100.0f;
		}

		_transform.position = _pos;
	}
}
