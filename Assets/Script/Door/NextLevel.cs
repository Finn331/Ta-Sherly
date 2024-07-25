using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevel : MonoBehaviour
{
    [Header("Score Requirement")]
    [SerializeField] int scoreRequirement;
    [SerializeField] string nextLevelName;

    [Header("Setup")]
    [SerializeField] int levelAdd; // menggunakan pertambahan seperti 1 atau 0
    [SerializeField] GameObject interactButton;
    [SerializeField] GameObject loadingCanvas;
    [SerializeField] Slider loadingSlider;


    private bool canTeleport = false;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                PlayerStatus playerStatus = player.GetComponent<PlayerStatus>();
                if (playerStatus.score >= 49)
                {
                    interactButton.SetActive(true);
                    LeanTween.scale(interactButton, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutBack);
                    canTeleport = true;

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactButton.SetActive(false);
            LeanTween.scale(interactButton, new Vector3(0, 0, 0), 1f).setEase(LeanTweenType.easeOutBack);
            canTeleport = false;

        }
    }

    private void Update()
    {
        // Check for "E" key press in the Update method
        if (canTeleport && Input.GetKeyDown(KeyCode.E))
        {
            LoadingLevelBtn(nextLevelName);
            if (levelAdd == 2)
            {
                SaveManager.instance.level2Unlocked = true;
                SaveManager.instance.Save();
            }
            else if (levelAdd == 3)
            {
                SaveManager.instance.level3Unlocked = true;
                SaveManager.instance.Save();
            }
            Debug.Log("teleport ke " + name);
        }
    }

    public void LoadingLevelBtn(string nextLevelName)
    {
        loadingCanvas.SetActive(true);
        
        StartCoroutine(LoadLevel(nextLevelName));
    }

    IEnumerator LoadLevel(string nextLevelName)
    {
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(nextLevelName);
        Time.timeScale = 1;
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            loadingSlider.value = progress;

            yield return null;
        }
    }
}
