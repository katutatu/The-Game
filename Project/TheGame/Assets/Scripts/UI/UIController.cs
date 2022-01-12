using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>UI操作クラス</summary>
public static class UIController
{
    /// <summary>残機UI更新</summary>
    public static void UpdateStockUI(int stock)
    {
        var stockUI = UIManager.Instance.GetUI(BattleUITypes.Stock) as StockUI;
        if (stockUI != null)
        {
            stockUI.SetStockCount(stock);
        }
    } 
}