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
    public Button falseAnswer;
    public float textDuration = 1;
    private Color originalColor;

    [Header("Script Reference")]
    public LevelsManager levelsManager;
    public PlayerController playerController;

    void Start()
    {
        originalColor = rightAnswer.GetComponent<Image>().color;
    }

    public void TrueAnswer()
    {
        quizPanel.SetActive(false);
        Time.timeScale = 1;
        GameObject.Destroy(quizTrigger);
        //SaveManager.instance.coin += 5;
        levelsManager.isPaused = false;
        playerController.enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void WrongAnswer()
    {
        Time.timeScale = 1;
        // Mengubah warna tombol yang salah menjadi merah
        falseAnswer.GetComponent<Image>().color = Color.red;

        // Mengubah warna tombol yang benar menjadi hijau
        rightAnswer.GetComponent<Image>().color = Color.green;
        levelsManager.isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        // Menjalankan coroutine untuk mengatur ulang warna setelah durasi tertentu
        StartCoroutine(ResetButtonColors());

        // Mengaktifkan panel kuis dan mengatur ulang waktu
        
    }

    private IEnumerator ResetButtonColors()
    {
        yield return new WaitForSeconds(textDuration);
        quizPanel.SetActive(false);
        playerController.enabled = true;
        GameObject.Destroy(quizTrigger);
    }
}
