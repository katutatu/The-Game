using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>バトルの結果</summary>
public static class BattleResult
{
    public static int Score;
}

public class ResultScene : Scene
{
    public override void StartScene()
    {
        UIController.UpdateResultScoreUI(BattleResult.Score);
    }

    public override void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //リザルトが始まった瞬間にBGMを消すと悲しいのでボタンを押すまでは残す
            SoundManager.Instance.Stop(SoundNames.BGM_Game);
            
            SceneManager.Instance.ChangeScene(SceneNames.Title);
            SoundManager.Instance.Play(SoundNames.SE_Enter);
        }
    }
}
