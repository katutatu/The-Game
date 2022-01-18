using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreUI : UIBase
{
    [SerializeField]
    private Text _text = null;


    public void SetScore(string title, int score)
    {
        _text.text = title + ":" + score;
    }
}
