using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeTextButton : MonoBehaviour
{
    [Header("Volume Texts")]
    public TMP_Text sfxVolumeText;
    public TMP_Text bgmVolumeText;

    [Header("Audio Source Setting")]
    [SerializeField] AudioClip buttonClick;
    private void Start()
    {
        UpdateVolumeTexts();
    }

    public void IncreaseSFXVolume()
    {
        float newVolume = AudioManager.instance.GetSoundVolume() + 0.2f;
        if (newVolume > 1.0f)
        {
            newVolume = 0.0f;
        }
        AudioManager.instance.ChangeSoundVolume(newVolume);
        UpdateVolumeTexts();
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void IncreaseBGMVolume()
    {
        float newVolume = AudioManager.instance.GetMusicVolume() + 0.2f;
        if (newVolume > 1.0f)
        {
            newVolume = 0.0f;
        }
        AudioManager.instance.ChangeMusicVolume(newVolume);
        UpdateVolumeTexts();
        AudioManager.instance.PlaySound(buttonClick);
    }

    private void UpdateVolumeTexts()
    {
        sfxVolumeText.text = $"{(AudioManager.instance.GetSoundVolume() * 100).ToString("F0")}%";
        bgmVolumeText.text = $"{(AudioManager.instance.GetMusicVolume() * 100).ToString("F0")}%";
    }
}
