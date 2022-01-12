using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>機体操作ベースクラス</summary>
public abstract class Pilot
{
    protected IPlaneCockpit _plane { get; private set; }


    /// <summary>セットアップ</summary>
    public void Setup(IPlaneCockpit plane)
    {
        _plane = plane;
    }

    /// <summary>毎フレ呼ばれる</summary>
    public abstract void Tick();
}
