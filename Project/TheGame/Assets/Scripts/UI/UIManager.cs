using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleUITypes
{
    /// <summary>なし</summary>
    None,
    /// <summary>残機</summary>
    Stock,
    /// <summary>スコア</summary>
    Score,
}

public enum ResultUITypes
{
    /// <summary>なし</summary>
    None,
    /// <summary>スコア</summary>
    Score,
    /// <summary>ハイスコア</summary>
    High,
}

/// <summary>全てのシーンのUIを管理するクラス</summary>
public class UIManager : SingletonMonoBehaviour<UIManager>
{
    private BattleUI _battleUI;
    private ResultUI _resultUI;


    public void BindSceneUI(string sceneName)
    {
        if (SceneNames.IsBattleSceneName(sceneName))
        {
            _battleUI = FindObjectOfType<BattleUI>();
        }
        else if (sceneName == SceneNames.Result)
        {
            _resultUI = FindObjectOfType<ResultUI>();
        }
    }

    public void UnbindSceneUI()
    {
        _battleUI = null;
        _resultUI = null;
    }

    public UIBase GetUI(BattleUITypes battleUIType)
    {
        return _battleUI?.GetUI(battleUIType);
    }
    public UIBase GetUI(ResultUITypes resultUIType)
    {
        return _resultUI?.GetUI(resultUIType);
    }
}
