using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizSystem : MonoBehaviour
{
    [Header("Quiz System")]
    public GameObject quizPanel;
    public GameObject quizTrigger;
    public GameObject kamuBenarImage;
    public GameObject kamuSalahImage;
    public float textDuration = 1;
    public LeanTweenType easingType;

    [Header("Script Reference")]
    public LevelsManager levelsManager;
    [SerializeField] LevelManager2 levelManager2;
    [SerializeField] LevelManager3 levelManager3;
    public PlayerController playerController;
    public PlayerController playerController2;

    [Header("Audio Clip")]
    [SerializeField] AudioClip kamuBenarClip;
    [SerializeField] AudioClip kamuSalahClip;

    void Start()
    {
        // Initialization code
    }

    public void TrueAnswer()
    {
        StartCoroutine(DeactivateQuizPanelWithDelay());
        Time.timeScale = 1;
        GameObject.Destroy(quizTrigger);
        LeanTween.scale(kamuBenarImage, new Vector3(1, 1, 1), 1.3f).setEase(easingType);

        if (levelsManager != null)
        {
            levelsManager.isPaused = false;
        }

        if (levelManager2 != null)
        {
            levelManager2.isPaused = false;
        }

        if (levelManager3 != null)
        {
            levelManager3.isPaused = false;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.enabled = true;
        playerController2.enabled = true;

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            PlayerStatus playerStatus = player.GetComponent<PlayerStatus>();
            if (playerStatus != null)
            {
                playerStatus.score += 5;
                AudioManager.instance.PlaySound(kamuBenarClip);
            }
        }
    }


    public void WrongAnswer()
    {
        StartCoroutine(DeactivateQuizPanelWithDelay());
        Time.timeScale = 1;
        LeanTween.scale(kamuSalahImage, new Vector3(1, 1, 1), 1.3f).setEase(easingType);
        if (levelsManager != null)
        {
            levelsManager.isPaused = false;
        }

        if (levelManager2 != null)
        {
            levelManager2.isPaused = false;
        }

        if (levelManager3 != null)
        {
            levelManager3.isPaused = false;
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.enabled = true;
        playerController2.enabled = true;
        GameObject.Destroy(quizTrigger);
        AudioManager.instance.PlaySound(kamuSalahClip);
    }

    private IEnumerator DeactivateQuizPanelWithDelay()
    {
        yield return new WaitForSeconds(1.4f);
        quizPanel.SetActive(false);
    }
}
