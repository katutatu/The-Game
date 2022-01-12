using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>COM機体操作クラス</summary>
public class ComPilot : Pilot
{
    public override void Tick()
    {
        if (!_plane.IsDead)
        {
            _plane.Move(Vector3.forward);
        }
    }
}
