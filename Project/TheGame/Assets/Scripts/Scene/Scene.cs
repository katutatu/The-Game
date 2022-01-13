using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene : MonoBehaviour
{
    public virtual void StartScene() { }
    public virtual IEnumerator StartSceneAsync() { yield break; }
    public virtual void FixedTick() { }
    public virtual void Tick() { }
    public virtual void EndScene() { }
    public virtual IEnumerator EndSceneAsync() { yield break; }
}
