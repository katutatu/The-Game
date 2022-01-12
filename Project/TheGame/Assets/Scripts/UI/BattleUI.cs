using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    [SerializeField]
    private StockUI _stock;

    [SerializeField]
    private ScoreUI _score;


    public UIBase GetUI(BattleUITypes battleUIType)
    {
        switch (battleUIType)
        {
            case BattleUITypes.Stock:
                return _stock;
            case BattleUITypes.Score:
                return _score;
            default:
                return null;
        }
    }
}
