using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    /// <summary>残機</summary>
    private UIBase _Stock;


    private void Setup()
    {
    }

    public UIBase GetUI(BattleUITypes battleUIType)
    {
        switch (battleUIType)
        {
            case BattleUITypes.Stock:
                return _Stock;
            default:
                return null;
        }
    }
}
