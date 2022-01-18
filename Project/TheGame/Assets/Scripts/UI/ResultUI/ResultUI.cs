using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [SerializeField]
    private ResultScoreUI _scoreUI;
    [SerializeField]
    private ResultScoreUI _hightScoreUI;


    public UIBase GetUI(ResultUITypes resultUIType)
    {
        switch (resultUIType)
        {
            case ResultUITypes.Score:
                return _scoreUI;
            case ResultUITypes.High:
                return _hightScoreUI;
            default:
                return null;
        }
    }
}
