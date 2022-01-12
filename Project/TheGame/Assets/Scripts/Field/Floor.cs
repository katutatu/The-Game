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
		Vector3 _scale = _transform.localScale;

		//床移動のスピード
		const float _floorSpeed = 0.01f;
		_pos.z -= _floorSpeed;

		//*10は1グリッドのサイズっぽい
		float _floorSize = _scale.z * 10.0f;
		if (_pos.z <= -_floorSize)
		{
			_pos.z = _floorSize;
		}

		_transform.position = _pos;
	}
}
