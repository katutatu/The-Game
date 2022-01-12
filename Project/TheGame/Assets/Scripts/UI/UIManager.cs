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

/// <summary>全てのシーンのUIを管理するクラス</summary>
public class UIManager : SingletonMonoBehaviour<UIManager>
{
    private BattleUI _battleUI;


    public void Setup()
    {
        // 仮 シーンが一つしかないのでこれで上手くいってるだけ
        _battleUI = FindObjectOfType<BattleUI>();
    }

    public UIBase GetUI(BattleUITypes battleUIType)
    {
        return _battleUI?.GetUI(battleUIType);
    }
}
