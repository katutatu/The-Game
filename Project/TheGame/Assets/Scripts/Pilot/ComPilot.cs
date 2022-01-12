using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>COM機体操作クラス</summary>
public class ComPilot : Pilot
{
    private IPlaneReadOnly _playerPlane;


    public void SetPlayerPlane(IPlaneReadOnly playerPlane)
    {
        _playerPlane = playerPlane;
    }

    public override void TickActive()
    {
        if (!_plane.IsDead)
        {
            _plane.Move(Vector3.back);
        }
    }
}
