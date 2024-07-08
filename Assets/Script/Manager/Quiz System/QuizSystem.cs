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
    public Button rightAnswer;
    public GameObject kamuBenarImage;
    public Button falseAnswer;
    public GameObject kamuSalahImage;
    public float textDuration = 1;
    public LeanTweenType easingType;

    [Header("Script Reference")]
    public LevelsManager levelsManager;
    public PlayerController playerController;

    void Start()
    {
        //initialization code
    }

    public void TrueAnswer()
    {
        StartCoroutine(DeactivateQuizPanelWithDelay());
        Time.timeScale = 1;
        GameObject.Destroy(quizTrigger);
        LeanTween.scale(kamuBenarImage, new Vector3(1, 1, 1), 0.5f).setEase(easingType);
        levelsManager.isPaused = false;
        playerController.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void WrongAnswer()
    {
        StartCoroutine(DeactivateQuizPanelWithDelay());
        Time.timeScale = 1;
        LeanTween.scale(kamuSalahImage, new Vector3(1, 1, 1), 0.5f).setEase(easingType);
        levelsManager.isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        playerController.enabled = true;
        GameObject.Destroy(quizTrigger);
    }

    private IEnumerator DeactivateQuizPanelWithDelay()
    {
        yield return new WaitForSeconds(0.8f);
        quizPanel.SetActive(false);
    }
}
