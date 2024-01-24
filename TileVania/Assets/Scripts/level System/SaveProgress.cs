using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveProgress 
{
    private const string _CURRENT_LEVEL_ID_KEY = "CurrentLevel";
    private const string _MUSIC_VOLUME_KEY = "Music";
    private const string _VFX_VOLUME_KEY = "Vfx";

    public static void SetLevelAsCompleted(string idLevel)
    {
        PlayerPrefs.SetInt(idLevel, 1);
    }

    public static void SetCurrentLevelId (string idLevel)
    {
        PlayerPrefs.SetString(_CURRENT_LEVEL_ID_KEY,idLevel);
    }

    public static void SetMusicVolume(float volume)
    {
        PlayerPrefs.SetFloat(_MUSIC_VOLUME_KEY, volume);
    }
    public static void SetVfxVolume(float volume)
    {
        PlayerPrefs.SetFloat(_VFX_VOLUME_KEY, volume);
    }

}
