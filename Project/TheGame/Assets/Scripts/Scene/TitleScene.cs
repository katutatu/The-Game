using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : Scene
{
    public override void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.Instance.ChangeScene(SceneNames.StageSelect);
            SoundManager.Instance.Play(SoundNames.SE_Enter);
        }
    }
}
