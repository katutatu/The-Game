using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCamera : MonoBehaviour
{
    private const float ArrivalDistance = 0.1f;

    [SerializeField]
    private Vector3 _offset;



    private IPlaneReadOnly _targetPlane;


    public void SetTargetPlane(IPlaneReadOnly targetPlane)
    {
        _targetPlane = targetPlane;
    }

    private void Update()
    {
        if (_targetPlane != null)
        {
            var goalPos = _targetPlane.Position + _offset;
            var goalToCurrent = goalPos - transform.position;
            var move = goalToCurrent * Time.deltaTime * 10.0f;
            transform.position += move;
        }
    }
}
