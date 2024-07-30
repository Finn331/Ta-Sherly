using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuManager : MonoBehaviour
{
    [Header("Setting Panel")]
    public GameObject settingPanel;
    public GameObject settingButton;

    [Header("Character Selection Settings")]
    public GameObject characterPanel;
    public GameObject characterSelectionButtonPanel;
    public GameObject backgroundSelection;
    public GameObject character1Prefabs;
    public GameObject character2Prefabs;
    private bool characterSelected;

    [Header("Selection Level Setting")]
    public GameObject selectionLevelPanel;
    public GameObject selectionLevelButtonPanel;
    [SerializeField] Button level2;
    [SerializeField] Button level3;
    [SerializeField] TextMeshProUGUI level1LastScore;
    [SerializeField] TextMeshProUGUI level2LastScore;
    [SerializeField] TextMeshProUGUI level3LastScore;

    [Header("Button Panel & Header Mainmenu")]
    public GameObject headerMenu;
    public GameObject actionPanel;
    public GameObject buttonPanel;
    public GameObject backgroundMainmenu;

    [Header("Menu Belajar Setting")]
    public GameObject menuBelajarBackground;
    public GameObject menuBelajarPanel;
    public GameObject menuBelajarButton;
    [SerializeField] Button menuMenulisButton;
    [SerializeField] GameObject comingSoonHolder;
    [Header("Info Holder")]
    [SerializeField] GameObject infoHolder;
    [SerializeField] GameObject infoCloseButton;
    [SerializeField] GameObject infoPanel;

    [Header("Loading Screen")]
    [SerializeField] GameObject loadingScreen;
    [SerializeField] GameObject menuCanvas;

    [Header("Slider")]
    [SerializeField] Slider loadingSlider;

    [Header("Audio Clip")]
    [SerializeField] AudioClip buttonClick;
    [SerializeField] AudioClip bgmSong;

    private void Awake()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SaveManager.instance.isFirstTime = false;
        SaveManager.instance.Save();
        AudioManager.instance.PlayMusic(bgmSong, true);

        MenuMenulisCheck();
        LevelCheck();
        LastScore();
        // GA GUNA
        //PlayerPrefs.SetInt("Level 1", 0);
        //PlayerPrefs.SetInt("Level 2", 0);
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
        backgroundMainmenu.SetActive(false);

        AudioManager.instance.PlaySound(buttonClick);
    }

    public void InfoPanel()
    {

        infoHolder.SetActive(true);
        infoCloseButton.SetActive(true);
        infoPanel.SetActive(true);
        LeanTween.scale(infoHolder, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void CloseInfoPanel()
    {

        AudioManager.instance.PlaySound(buttonClick);
        infoCloseButton.SetActive(false);
        infoPanel.SetActive(false);
        LeanTween.scale(infoHolder, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() => infoHolder.SetActive(false));
    }

    public void Setting()
    {
        settingPanel.SetActive(true);
        settingButton.SetActive(true);
        LeanTween.scale(settingButton, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySound(buttonClick);
        Application.Quit();
    }

    // Button Functions
    public void SettingBack()
    {
        AudioManager.instance.PlaySound(buttonClick);
        settingPanel.SetActive(false);
        settingButton.SetActive(false);
        settingButton.transform.localScale = Vector3.zero;
    }

    // Menu Belajar
    public void MenuBelajar()
    {
        AudioManager.instance.PlaySound(buttonClick);
        menuBelajarBackground.SetActive(true);
        menuBelajarButton.SetActive(true);
        menuBelajarPanel.SetActive(true);
        LeanTween.scale(menuBelajarPanel, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);

        headerMenu.SetActive(false);
        actionPanel.SetActive(false);
        buttonPanel.SetActive(false);
        backgroundMainmenu.SetActive(false);
    }

    public void MenuBelajarBack()
    {
        AudioManager.instance.PlaySound(buttonClick);
        menuBelajarButton.SetActive(false);
        menuBelajarBackground.SetActive(false);
        menuBelajarPanel.transform.localScale = Vector3.zero;
        menuBelajarPanel.SetActive(false);
        comingSoonHolder.SetActive(false);
        comingSoonHolder.transform.localScale = Vector3.zero;

        headerMenu.SetActive(true);
        actionPanel.SetActive(true);
        buttonPanel.SetActive(true);
        backgroundMainmenu.SetActive(true);
    }

    // Selection Character
    public void SelectCharacter()
    {
        AudioManager.instance.PlaySound(buttonClick);
        character1Prefabs.SetActive(true);
        PlayerPrefs.SetInt("Character", 1);
        PlayerPrefs.Save();
        characterSelected = true;
    }

    public void SelectCharacter2()
    {
        AudioManager.instance.PlaySound(buttonClick);
        character2Prefabs.SetActive(true);
        PlayerPrefs.SetInt("Character", 2);
        PlayerPrefs.Save();
        characterSelected = true;
    }

    public void BackButtonCharacterSelect()
    {
        AudioManager.instance.PlaySound(buttonClick);
        characterPanel.SetActive(false);
        characterSelectionButtonPanel.SetActive(false);
        backgroundSelection.SetActive(false);

        headerMenu.SetActive(true);
        actionPanel.SetActive(true);
        buttonPanel.SetActive(true);
        backgroundMainmenu.SetActive(true);
    }

    // Select Level
    public void SelectLevel()
    {
        AudioManager.instance.PlaySound(buttonClick);
        characterPanel.SetActive(false);
        characterSelectionButtonPanel.SetActive(false);
        backgroundSelection.SetActive(false);

        selectionLevelPanel.SetActive(true);
        selectionLevelButtonPanel.SetActive(true);

        level1LastScore.enabled = true;
        level2LastScore.enabled = true;
        level3LastScore.enabled = true;
    }

    public void SelectLevelBack()
    {
        AudioManager.instance.PlaySound(buttonClick);
        characterPanel.SetActive(true);
        characterSelectionButtonPanel.SetActive(true);
        backgroundSelection.SetActive(true);

        selectionLevelPanel.SetActive(false);
        selectionLevelButtonPanel.SetActive(false);

        level1LastScore.enabled = false;
        level2LastScore.enabled = false;
        level3LastScore.enabled = false;
    }

    // Async Loader
    public void LoadingLevelBtn(string levelToLoad)
    {
        menuCanvas.SetActive(false);
        loadingScreen.SetActive(true);
        backgroundSelection.SetActive(false);

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

    void LevelCheck()
    {
        if (SaveManager.instance.level2Unlocked == false)
        {
            SaveManager.instance.level2Unlocked = false;

        }

        if (SaveManager.instance.level3Unlocked == false)
        {
            SaveManager.instance.level3Unlocked = false;

        }

        if (SaveManager.instance.level2Unlocked == true)
        {
            level2.interactable = true;
        }

        if (SaveManager.instance.level3Unlocked == true)
        {
            level3.interactable = true;
        }
    }

    void LastScore()
    {

        level1LastScore.text = "Last Score: " + SaveManager.instance.level1Score.ToString();
        level2LastScore.text = "Last Score: " + SaveManager.instance.level2Score.ToString();
        level3LastScore.text = "Last Score: " + SaveManager.instance.level3Score.ToString();
    }

    void MenuMenulisCheck()
    {
        if (SaveManager.instance.menuGambarUnlocked == true)
        {
            menuMenulisButton.interactable = true;
        }
    }

    public void MenuMenulis()
    {
        AudioManager.instance.PlaySound(buttonClick);
        comingSoonHolder.SetActive(true);
        LeanTween.scale(comingSoonHolder, new Vector3(1, 1, 1), 0.5f).setEase(LeanTweenType.easeOutBack);

        menuBelajarBackground.SetActive(true);
        menuBelajarButton.SetActive(false);
        menuBelajarPanel.SetActive(false);
    }

    public void MenuMenulisBack()
    {
        AudioManager.instance.PlaySound(buttonClick);
        LeanTween.scale(comingSoonHolder, new Vector3(0, 0, 0), 0.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(() => comingSoonHolder.SetActive(false));
        menuBelajarBackground.SetActive(true);
        menuBelajarButton.SetActive(true);
        menuBelajarPanel.SetActive(true);
    }

    public void MenuBelajarVideo()
    {
        AudioManager.instance.PlaySound(buttonClick);
        SceneManager.LoadScene("BelajarVideo");
    }
}
