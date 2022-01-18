using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public static class StaticUserData
{
    private static readonly string UserDataPath = Path.Combine(Application.persistentDataPath, "UserData.json");


    public static UserData Instance = new UserData();


    public static void Load()
    {
        using (var sr = new StreamReader(new FileStream(UserDataPath, FileMode.OpenOrCreate, FileAccess.Read)))
        {
            var json = sr.ReadToEnd();
            JsonUtility.FromJsonOverwrite(json, Instance);
        }
    }

    public static void Save()
    {
        using (var sw = new StreamWriter(new FileStream(UserDataPath, FileMode.OpenOrCreate, FileAccess.Write)))
        {
            var json = JsonUtility.ToJson(Instance);
            sw.Write(json);
        }
    }
}
