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
        transform.position = GetGoalPosition();
    }

    private void Update()
    {
        if (_targetPlane != null)
        {
            var currentToGoal = GetGoalPosition() - transform.position;
            var move = currentToGoal * Time.deltaTime * 10.0f;
            transform.position += move;
        }
    }

    private Vector3 GetGoalPosition()
    {
        if (_targetPlane == null)
        {
            return Vector3.zero;
        }
        return _targetPlane.Position + _offset;
    }
}
