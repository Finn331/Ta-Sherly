using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainmenuManager : MonoBehaviour
{
    [Header("Setting Panel")]
    public GameObject settingPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Mechanism Functions

    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
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
}
