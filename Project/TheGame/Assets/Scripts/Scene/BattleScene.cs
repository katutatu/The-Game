using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : Scene
{
    private bool _isEnd;
    private GODClass _godClass;


    public override void StartScene()
    {
        _godClass = FindObjectOfType<GODClass>();
    }

    public override void Tick()
    {
        if (!_isEnd)
        {
            _isEnd = _godClass != null && _godClass.IsEnd();
            if (_isEnd)
            {
                SceneManager.Instance.ChangeScene(SceneNames.Result);
            }
        }
    }
}
