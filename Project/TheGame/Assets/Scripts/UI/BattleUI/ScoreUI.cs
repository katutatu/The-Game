using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : UIBase
{
    [SerializeField]
    private Text _text;


    private int _score;


    public void SetScore(int score)
    {
        _score = score;
        _text.text = "SCORE: " + _score;
    }
}
