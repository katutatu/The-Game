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

		//���ړ��̃X�s�[�h
		const float _floorSpeed = 0.02f;
		_pos.z -= _floorSpeed;

		//*10��1�O���b�h�̃T�C�Y���ۂ�
		float _floorSize = _scale.z * 10.0f;
		if (_pos.z <= -_floorSize)
		{
			_pos.z = _floorSize;
		}

		_transform.position = _pos;
	}
}
