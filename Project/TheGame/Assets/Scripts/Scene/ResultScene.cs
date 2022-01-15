using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScene : Scene
{
    public override void Tick()
    {
        if (Input.GetMouseButton(0))
        {
            SceneManager.Instance.ChangeScene(SceneNames.Title);
        }
    }
}
