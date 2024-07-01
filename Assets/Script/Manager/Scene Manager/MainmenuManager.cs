using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuManager : MonoBehaviour
{
    [Header("Setting Panel")]
    public GameObject settingPanel;

    [Header("Character Selection Settings")]
    public GameObject characterPanel;
    public GameObject characterSelectionButtonPanel;
    public GameObject backgroundSelection;
    public GameObject character1Prefabs;
    public GameObject character2Prefabs;
    private bool characterSelected;

    [Header("Button Panel & Header Mainmenu")]
    public GameObject headerMenu;
    public GameObject actionPanel;
    public GameObject buttonPanel;

    [Header("Loading Screen")]
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject menuCanvas;

    [Header("Slider")]
    [SerializeField] Slider loadingSlider;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Level 1", 0);
        PlayerPrefs.SetInt("Level 2", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Mechanism Functions

    public void PlayGame()
    {
        //if (characterSelected == true)
        //{

        //}else
        characterPanel.SetActive(true);
        characterSelectionButtonPanel.SetActive(true);
        backgroundSelection.SetActive(true);
        headerMenu.SetActive(false);
        actionPanel.SetActive(false);
        buttonPanel.SetActive(false);
    }

    public void Setting()
    {
        settingPanel.SetActive(true);

        LeanTween.scale(settingPanel, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Button Functions
    public void SettingBack()
    {
        LeanTween.scale(settingPanel, new Vector3(0, 0, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        LeanTween.delayedCall(0.5f, () => settingPanel.SetActive(false));
    }

    // Selection Character
    public void SelectCharacter()
    {
        character1Prefabs.SetActive(true);
        PlayerPrefs.SetInt("Character", 1);
        PlayerPrefs.Save();
        characterSelected = true;
    }

    public void SelectCharacter2()
    {
        character2Prefabs.SetActive(true);
        PlayerPrefs.SetInt("Character", 2);
        PlayerPrefs.Save();
        characterSelected = true;
    }
    
    public void BackButtonCharacterSelect()
    {
        characterPanel.SetActive(false);
        characterSelectionButtonPanel.SetActive(false);
        backgroundSelection.SetActive(false);
        headerMenu.SetActive(true);
        actionPanel.SetActive(true);
        buttonPanel.SetActive(true);
    }

    // Async Loader
    public void LoadingLevelBtn(string levelToLoad)
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
