using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager 
{
    public int Score { get; private set; }


    /// <summary>スコア変更時のイベント 引数: 変化後のスコア</summary>
    public System.Action<int> OnScoreChanged;


    public void UpdateScore(int changeScore)
    {
        Score += changeScore;
        if (Score < 0)
        {
            Score = 0;
        }

        OnScoreChanged?.Invoke(Score);
    }
}
