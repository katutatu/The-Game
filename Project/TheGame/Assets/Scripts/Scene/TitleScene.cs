using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : Scene
{
    public override void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.Instance.ChangeScene(SceneNames.Stage1);
            SoundManager.Instance.Play(SoundNames.SE_Enter);
        }
    }
}
