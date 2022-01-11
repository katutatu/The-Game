using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleUITypes
{
    /// <summary>なし</summary>
    None,
    /// <summary>残機</summary>
    Stock,
}

/// <summary>全てのシーンのUIを管理するクラス</summary>
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private BattleUI _battleUI = null;


    public UIBase GetUI(BattleUITypes battleUIType)
    {
        return _battleUI?.GetUI(battleUIType);
    }
}
