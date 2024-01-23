using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreensOnMainMenu : MonoBehaviour
{
    [SerializeField]
    private SimpleCanvasController _canvasController;

    [SerializeField]
    private GameObject _levelsScreen;

    private const string _CURRENT_LEVEL_ID_KEY = "CurrentLevel";
    private const string _MAIN_MENU_LEVEL_NAME = "MainMenu";
    private const string _MAIN_MENU_LEVEL_SELECTOR_NAME = "LevelSelector";

    private void Start()
    {
        if (PlayerPrefs.GetString(_CURRENT_LEVEL_ID_KEY, _MAIN_MENU_LEVEL_NAME).Equals(_MAIN_MENU_LEVEL_SELECTOR_NAME))
        {
            _canvasController.ShowScreen(_levelsScreen);
            SaveProgress.SetCurrentLevelId(_MAIN_MENU_LEVEL_NAME);
        }
    }
}
