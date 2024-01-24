using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private Slider _musicSlider;
    [SerializeField]
    private Slider _vfxSlider;

    private const string _MUSIC_VOLUME_KEY = "Music";
    private const string _VFX_VOLUME_KEY = "Vfx";

    private void Start()
    {
        _musicSlider.onValueChanged.AddListener(SaveMusicVolume);
        _vfxSlider.onValueChanged.AddListener(SaveVfxVolume);

        _musicSlider.value = PlayerPrefs.GetFloat(_MUSIC_VOLUME_KEY, 0.5f);
        _vfxSlider.value = PlayerPrefs.GetFloat(_VFX_VOLUME_KEY, 0.5f);
    }

    private void SaveMusicVolume(float value)
    {
        SaveProgress.SetMusicVolume(value);
        AudioSystem.Instance.SetupMusicVolume(value);
    }
    private void SaveVfxVolume(float value)
    {
        SaveProgress.SetVfxVolume(value);
        AudioSystem.Instance.SetupVfxVolume(value);
    }
}
