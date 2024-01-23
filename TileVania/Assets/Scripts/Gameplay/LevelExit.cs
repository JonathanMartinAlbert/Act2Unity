using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField]
    private string _Idlevel;

    [SerializeField] float levelLoadDelay = 1f;

    private const string _MAIN_MENU_LEVEL_NAME = "MainMenu";
    private const string _MAIN_MENU_LEVEL_SELECTOR_NAME = "LevelSelector";

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(LoadNextLevel());
        }
    }

    IEnumerator LoadNextLevel()
    {
        SaveProgress.SetCurrentLevelId(_MAIN_MENU_LEVEL_SELECTOR_NAME);
        SaveProgress.SetLevelAsCompleted(_Idlevel);
        yield return new WaitForSecondsRealtime(levelLoadDelay);
        
        SceneManager.LoadScene(_MAIN_MENU_LEVEL_NAME);
    }
}
