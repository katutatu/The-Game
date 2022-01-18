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

    /// <summary>スコアUI更新</summary>
    public static void UpdateScoreUI(int score)
    {
        var scoreUI = UIManager.Instance.GetUI(BattleUITypes.Score) as ScoreUI;
        if (scoreUI != null)
        {
            scoreUI.SetScore(score);
        }
    }

    /// <summary>リザルトスコアUI更新</summary>
    public static void UpdateResultScoreUI(int score)
    {
        var scoreUI = UIManager.Instance.GetUI(ResultUITypes.Score) as ResultScoreUI;
        if (scoreUI != null)
        {
            scoreUI.SetScore("SCORE", score);
        }
    }

    /// <summary>リザルトハイスコアUI更新</summary>
    public static void UpdateResultHighScoreUI(int highScore)
    {
        var scoreUI = UIManager.Instance.GetUI(ResultUITypes.High) as ResultScoreUI;
        if (scoreUI != null)
        {
            scoreUI.SetScore("HIGH SCORE", highScore);
        }
    }
}
