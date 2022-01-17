using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleScene : Scene
{
    enum EndType
    {
        None,
        Clear,
        Dead,
    }

    private EndType _endType;
    private BattleController _battleController;

    public override void StartScene()
    {
        _battleController = FindObjectOfType<BattleController>();
        _battleController.Setup();
    }

    public override void Tick()
    {
        if (_endType == EndType.None)
        {
            _battleController.Tick();

            if(_battleController != null)
            {
                if(_battleController.IsClearGame())
                {
                    _endType = EndType.Clear;
                }
                else if(_battleController.IsDeadPlayer())
                {
                    _endType = EndType.Dead;
                }
            }

            if (_endType != EndType.None)
            {
                SceneManager.Instance.ChangeScene(SceneNames.Result);
            }
        }
    }
}
