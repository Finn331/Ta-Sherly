using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VolumeTextUpdater : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI musicVolumeText;
    [SerializeField] private TextMeshProUGUI soundVolumeText;

    private void OnEnable()
    {
        // Update the text initially
        UpdateMusicVolumeText();
        UpdateSoundVolumeText();
    }

    private void Update()
    {
        // Continuously update the text in case of changes
        UpdateMusicVolumeText();
        UpdateSoundVolumeText();
    }

    private void UpdateMusicVolumeText()
    {
        if (musicVolumeText != null && AudioManager.instance != null)
        {
            musicVolumeText.text = $"{Mathf.RoundToInt(AudioManager.instance.GetMusicVolume() * 100)}%";
        }
    }

    private void UpdateSoundVolumeText()
    {
        if (soundVolumeText != null && AudioManager.instance != null)
        {
            soundVolumeText.text = $"{Mathf.RoundToInt(AudioManager.instance.GetSoundVolume() * 100)}%";
        }
    }
}
