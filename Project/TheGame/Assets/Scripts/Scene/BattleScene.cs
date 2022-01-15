using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : Scene
{
    private bool _isEnd;
    private BattleController _battleController;


    public override void StartScene()
    {
        _battleController = FindObjectOfType<BattleController>();
    }

    public override void Tick()
    {
        if (!_isEnd)
        {
            _isEnd = _battleController != null && _battleController.IsEnd();
            if (_isEnd)
            {
                SceneManager.Instance.ChangeScene(SceneNames.Result);
            }
        }
    }
}
