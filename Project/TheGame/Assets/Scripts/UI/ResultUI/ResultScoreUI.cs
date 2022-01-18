using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScoreUI : UIBase
{
    [SerializeField]
    private Text _text = null;


    public void SetScore(int score)
    {
        _text.text = "SCORE:" + score;
    }
}
