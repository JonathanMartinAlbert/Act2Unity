using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class AudioSystem : MonoBehaviour
{
    [SerializeField]
    private float _fadeDuration = 1.5f;


    [SerializeField]
    private AudioSource _musicAudioSource;
    [SerializeField]
    private AudioSource _vfxAudioSource;

    [SerializeField]
    private List<SoundData> _musicData = new();

    [SerializeField]
    private List<SoundData> _vfxData = new();

    private float _targetVolume = 1.0f;

    public static AudioSystem Instance;

    private const string _MUSIC_VOLUME_KEY = "Music";
    private const string _VFX_VOLUME_KEY = "Vfx";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
        SetupVolume();
    }

    public void PlayMusic(string musicId)
    {
        List<SoundData> soundToPlay = _musicData.FindAll(x => x.Id == musicId);
        if (soundToPlay != null)
        {
            ChangeSound(soundToPlay[UnityEngine.Random.Range(0, soundToPlay.Count)].Sound);
        }
    }

    public void PlayVfx(string vfxId)
    {
        AudioClip soundToPlay = _vfxData.Find(x => x.Id == vfxId).Sound;
        if (soundToPlay != null)
        {
            _vfxAudioSource.PlayOneShot(soundToPlay);
        }
    }

    private void SetupVolume()
    {
        _targetVolume = PlayerPrefs.GetFloat(_MUSIC_VOLUME_KEY, 1);
        _musicAudioSource.volume = _targetVolume;
        _vfxAudioSource.volume = PlayerPrefs.GetFloat(_VFX_VOLUME_KEY, 1);
    }

    public void SetupMusicVolume(float value)
    {
        _targetVolume = value;
        _musicAudioSource.volume = _targetVolume;
    }
    public void SetupVfxVolume(float value)
    {
        _vfxAudioSource.volume = value;
    }
    private void ChangeSound(AudioClip newClip)
    {
        StartCoroutine(FadeOutAndIn(newClip));
    }

    IEnumerator FadeOutAndIn(AudioClip newClip)
    {
        float elapsedTime = 0;

        while (elapsedTime < (_fadeDuration/2))
        {
            _musicAudioSource.volume = Mathf.Lerp(_targetVolume, 0, elapsedTime / _fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _musicAudioSource.Stop();
        _musicAudioSource.clip = newClip;
        _musicAudioSource.Play();

        elapsedTime = 0;
        while (elapsedTime < _fadeDuration)
        {
            _musicAudioSource.volume = Mathf.Lerp(0, _targetVolume, elapsedTime / _fadeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _musicAudioSource.volume = _targetVolume;
    }
}

[System.Serializable]
public class SoundData
{
    public string Id;
    public AudioClip Sound;
}