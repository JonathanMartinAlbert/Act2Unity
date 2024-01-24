using System;
using UnityEngine;
using UnityEngine.UI;

public class StageUI : MonoBehaviour
{
    [SerializeField]
    private string _levelId;

    [SerializeField]
    private Button _stageButton;

    [SerializeField]
    private GameObject _lockImage;

    private const string _FIRST_LEVEL_ID = "Level0";

    private void OnEnable()
    {
        if (_levelId == _FIRST_LEVEL_ID)
            return;

        int levelStatus = PlayerPrefs.GetInt(_levelId, 0);
        SetStageStatus(Convert.ToBoolean(levelStatus));
    }

    private void SetStageStatus(bool status)
    {
        _lockImage?.SetActive(!status);
        _stageButton.interactable = status;
    }

}
