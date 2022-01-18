using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    [SerializeField]
    private ResultScoreUI _resultScoreUI;


    public UIBase GetUI(ResultUITypes resultUIType)
    {
        switch (resultUIType)
        {
            case ResultUITypes.Score:
                return _resultScoreUI;
            default:
                return null;
        }
    }
}
