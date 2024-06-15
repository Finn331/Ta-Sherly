using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ASyncLoader : MonoBehaviour
{
    [Header("Menu Screen")]
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject menuCanvas;

    [Header("Slider")]
    [SerializeField] Slider loadingSlider;

    public void LoadLevelBtn(string levelToLoad)
    {
        menuCanvas.SetActive(false);
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
}
