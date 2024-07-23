using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class InitialscreenManager : MonoBehaviour
{
    [Header("Video Player")]
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private GameObject skipButton;

    [Header("Loading Screen")]
    [SerializeField] private Slider loadingSlider;
    [SerializeField] private GameObject loadingScreen; // Canvas Loading Screen

    // Start is called before the first frame update
    void Start()
    {
        SaveManager.instance.Load();
        // Tambahkan event handler untuk loopPointReached
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }

        ButtonChecker();
        //VideoChecker();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SkipVideo()
    {
        videoPlayer.Stop();
        //SceneLoader.Instance.LoadScene("Mainmenu");
        LoadingLevelBtn("Mainmenu");
    }

    void VideoChecker()
    {
        // Implementasikan logika yang ingin Anda lakukan ketika video selesai
        Debug.Log("Video telah selesai!");
        // Contoh: Langsung pindah ke scene Mainmenu
        LoadingLevelBtn("Mainmenu");
    }

    private void OnVideoEnd(VideoPlayer vp)
    {
        VideoChecker();
    }

    void ButtonChecker()
    {
        if (SaveManager.instance.isFirstTime == true)
        {
            skipButton.SetActive(false);
        }
        
        if (SaveManager.instance.isFirstTime == false)
        {
            skipButton.SetActive(true);
            //LeanTween.scale(skipButton, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        }
    }

    public void LoadingLevelBtn(string levelToLoad)
    {
        loadingScreen.SetActive(true);
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
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoEnd;
        }
    }
}
