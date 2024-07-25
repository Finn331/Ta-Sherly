using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InitialscreenManager : MonoBehaviour
{
    [Header("Video Player for Initial Screen")]
    [SerializeField] private VideoPlayer videoPlayerIS;
    [SerializeField] private GameObject panelVideoIS;

    [Header("Video Player for story")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject skipButton;
    [SerializeField] private GameObject canvasVideo;
    [SerializeField] private GameObject panelVideoStory;

    [Header("Loading Screen")]
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private GameObject loadingScreen; // Canvas Loading Screen

    void Start()
    {
        SaveManager.instance.Load();

        if (videoPlayerIS != null)
        {
            videoPlayerIS.loopPointReached += OnInitialVideoEnd;
            videoPlayerIS.Play();
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }

        ButtonChecker();
    }

    void Update()
    {
    }

    public void SkipVideo()
    {
        videoPlayer.Stop();
        canvasVideo.SetActive(false);
        LoadingLevelBtn("Mainmenu");
    }

    void VideoChecker()
    {
        Debug.Log("Video telah selesai!");
        canvasVideo.SetActive(false);
        LoadingLevelBtn("Mainmenu");
    }

    private void OnInitialVideoEnd(VideoPlayer vp)
    {
        panelVideoIS.SetActive(false);  // Matikan panel video initial screen
        videoPlayerIS.gameObject.SetActive(false);  // Matikan video player initial screen

        panelVideoStory.SetActive(true);  // Aktifkan panel video story
        videoPlayer.gameObject.SetActive(true);  // Aktifkan video player story
        canvasVideo.SetActive(true);  // Aktifkan canvas video
        videoPlayer.Play();  // Mainkan video story
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        VideoChecker();
    }

    void ButtonChecker()
    {
        if (SaveManager.instance.isFirstTime)
        {
            skipButton.SetActive(false);
        }
        else
        {
            skipButton.SetActive(true);
            //LeanTween.scale(skipButton, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        }
    }

    public void LoadingLevelBtn(string levelToLoad)
    {
        canvasVideo.SetActive(true);
        loadingScreen.SetActive(true);
        skipButton.SetActive(false);
        StartCoroutine(LoadLevel(levelToLoad));
    }

    IEnumerator LoadLevel(string levelToLoad)
    {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(levelToLoad);
        Time.timeScale = 1;
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;
            yield return null;
        }
    }

    void OnDestroy()
    {
        if (videoPlayerIS != null)
        {
            videoPlayerIS.loopPointReached -= OnInitialVideoEnd;
        }

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}
