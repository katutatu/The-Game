using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>プレイヤー機体操作クラス</summary>
public class PlayerPilot : Pilot
{
    public override void TickActive()
    {
        var moveVec = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            moveVec += Vector3.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveVec += Vector3.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveVec += Vector3.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveVec += Vector3.right;
        }
        if (moveVec != Vector3.zero)
        {
            _plane.Move(moveVec);
        }

        if (Input.GetMouseButton(0))
        {
            _plane.Shoot(Vector3.forward);
        }
    }
}
