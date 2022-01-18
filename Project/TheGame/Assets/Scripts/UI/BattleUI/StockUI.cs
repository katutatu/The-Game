using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockUI : UIBase
{
    [SerializeField]
    private Text _text;


    private int _stockCount;


    public void SetStockCount(int stockCount)
    {
        _stockCount = stockCount;
        _text.text = "残機x" + _stockCount;
    }
}
