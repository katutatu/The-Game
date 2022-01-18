using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : Scene
{
    public override void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.Instance.ChangeScene(SceneNames.Title);
            SoundManager.Instance.Play(SoundNames.SE_Enter);
        }
    }
}
