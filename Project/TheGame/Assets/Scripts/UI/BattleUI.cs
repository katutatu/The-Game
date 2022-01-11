using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    [SerializeField]
    private StockUI _stock;


    public UIBase GetUI(BattleUITypes battleUIType)
    {
        switch (battleUIType)
        {
            case BattleUITypes.Stock:
                return _stock;
            default:
                return null;
        }
    }
}
