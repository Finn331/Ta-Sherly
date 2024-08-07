using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    [Header("Setting Panel")]
    public GameObject settingPanel;
    public GameObject settingButton;
    [SerializeField] GameObject settingsButton;
    [Header("Gameobject Menu")]
    [SerializeField] private GameObject videoMenu1;
    [SerializeField] GameObject video1Button;
    [SerializeField] private GameObject videoMenu2;
    [SerializeField] GameObject video2Button;
    [SerializeField] GameObject homeButton;

    [Header("Canvas & Video Setting")]
    [SerializeField] private GameObject canvasVideo1;
    [SerializeField] private GameObject videoPembelajaran1;
    [SerializeField] private GameObject canvasVideo2;
    [SerializeField] private GameObject videoPembelajaran2;
    [SerializeField] private GameObject videoPlayer1;
    [SerializeField] private GameObject videoPlayer2;

    [SerializeField] private AudioClip buttonClick;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
        settingButton.SetActive(true);
        settingsButton.SetActive(false);
        
        LeanTween.scale(settingButton, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void CloseSetting()
    {
        settingButton.SetActive(false);
        settingsButton.SetActive(true);
        settingPanel.SetActive(false);
        LeanTween.scale(settingButton, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() =>
        {
            settingButton.SetActive(false);
        });
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void ShowVideoMenu1()
    {
        settingsButton.SetActive(true);
        homeButton.SetActive(false);
        videoMenu1.SetActive(false);
        video1Button.SetActive(false);
        videoMenu2.SetActive(false);
        video2Button.SetActive(false);
        //canvasVideo2.SetActive(false);
        //videoPembelajaran2.SetActive(false);
        //videoPlayer2.SetActive(false);

        canvasVideo1.SetActive(true);
        videoPembelajaran1.SetActive(true);
        videoPlayer1.SetActive(true);

        LeanTween.scale(videoPembelajaran1, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void BackShowVideoMenu1()
    {
        homeButton.SetActive(true);
        settingsButton.SetActive(true);
        videoMenu1.SetActive(true);
        video1Button.SetActive(true);
        videoMenu2.SetActive(true);
        video2Button.SetActive(true);

        canvasVideo1.SetActive(false);
        videoPembelajaran1.SetActive(false);
        videoPlayer1.SetActive(false);

        LeanTween.scale(videoPembelajaran1, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeOutBack);
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void ShowVideoMenu2()
    {
        homeButton.SetActive(false);
        settingsButton.SetActive(true);
        videoMenu1.SetActive(false);
        videoMenu2.SetActive(false);
        //canvasVideo1.SetActive(false);
        //videoPembelajaran1.SetActive(false);
        //videoPlayer1.SetActive(false);

        canvasVideo2.SetActive(true);
        videoPembelajaran2.SetActive(true);
        videoPlayer2.SetActive(true);

        LeanTween.scale(videoPembelajaran2, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void BackShowVideoMenu2()
    {
        homeButton.SetActive(true);
        settingsButton.SetActive(true);
        videoMenu1.SetActive(true);
        video1Button.SetActive(true);
        videoMenu2.SetActive(true);
        video2Button.SetActive(true);

        canvasVideo2.SetActive(false);
        videoPembelajaran2.SetActive(false);
        videoPlayer2.SetActive(false);

        LeanTween.scale(videoPembelajaran2, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeOutBack);
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Mainmenu");
        AudioManager.instance.PlaySound(buttonClick);
    }

    // Sound Setting
    //public void SetMusicVolumeFromSlider()
    //{
    //    AudioManager.instance.SetMusicVolumeFromSlider();
    //}

    //// Method to be called by the slider to set sound (SFX) volume
    //public void SetSoundVolumeFromSlider()
    //{
    //    AudioManager.instance.SetSoundVolumeFromSlider();
    //}
}
