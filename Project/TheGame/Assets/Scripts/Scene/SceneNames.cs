using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SceneNames
{
    public const string Title = "Title";
    public const string StageSelect = "StageSelect";
    public const string Stage1 = "Stage1";
    public const string Stage2 = "Stage2";
    public const string Result = "Result";


    public static bool IsBattleSceneName(string sceneName)
    {
        switch (sceneName)
        {
            case Stage1:
            case Stage2:
                return true;
            default:
                return false;
        }
    }
}
