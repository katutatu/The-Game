using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectScene : Scene
{
    public override void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeScene(SceneNames.Stage1);
        }
        if (Input.GetMouseButtonDown(1))
        {
            ChangeScene(SceneNames.Stage2);
        }
    }

    private void ChangeScene(string sceneName)
    {
        SceneManager.Instance.ChangeScene(sceneName);
        SoundManager.Instance.Play(SoundNames.SE_Enter);
    }
}
