using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectScene : Scene
{
    public override void Tick()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.Instance.ChangeScene(SceneNames.Stage1);
        }
    }
}
