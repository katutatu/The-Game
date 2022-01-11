using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>神クラス</summary>
public class GODClass : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.Setup();

        // 本来はプレイヤーから貰う
        var stockUI = UIManager.Instance.GetUI(BattleUITypes.Stock) as StockUI;
        if (stockUI != null)
        {
            stockUI.SetStockCount(5);
        }
    }
}
