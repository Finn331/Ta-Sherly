using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [Header("Player Script Reference")]
    [SerializeField] PlayerController playerController;
    [SerializeField] PlayerController playerController2;
    [SerializeField] PlayerAttack playerAttack;
    [SerializeField] PlayerAttack playerAttack2;

    [Header("Finish Level UI")]
    [SerializeField] GameObject finishLevelPanel;
    [SerializeField] GameObject finishLevelHolder;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Player Reference")]
    [SerializeField] GameObject player1;
    [SerializeField] GameObject player2;

    private int currScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currScore = FindObjectOfType<PlayerStatus>().score;
    }

    public void LevelFinished()
    {
        playerController.enabled = false;
        playerController2.enabled = false;
        playerAttack.enabled = false;
        playerAttack2.enabled = false;

        finishLevelPanel.SetActive(true);
        finishLevelHolder.SetActive(true);
        LeanTween.scale(finishLevelHolder, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutBack);

        if (player1 != null)
        {
            player1.SetActive(false);
        }

        if (player2 != null)
        {
            player2.SetActive(false);
        }

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        scoreText.text = "" + currScore;
        SaveManager.instance.menuGambarUnlocked = true;
        SaveManager.instance.Save();
        SaveCurrentScore();
    }

    private void SaveCurrentScore()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            SaveManager.instance.level1Score = currScore;
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            SaveManager.instance.level2Score = currScore;
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            SaveManager.instance.level3Score = currScore;
        }
        SaveManager.instance.Save();
    }
}
