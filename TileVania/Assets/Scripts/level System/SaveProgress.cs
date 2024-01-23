using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveProgress 
{
    private const string _CURRENT_LEVEL_ID_KEY = "CurrentLevel";

    public static void SetLevelAsCompleted(string idLevel)
    {
        PlayerPrefs.SetInt(idLevel, 1);
    }

    public static void SetCurrentLevelId (string idLevel)
    {
        PlayerPrefs.SetString(_CURRENT_LEVEL_ID_KEY,idLevel);
    }

}
