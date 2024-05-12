using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuizSystem : MonoBehaviour
{
    public GameObject quizPanel;
    public GameObject quizTrigger;
    public GameObject wrongText;

    public float textDuration = 1;

    public void TrueAnswer()
    {
        quizPanel.SetActive(false);
        Time.timeScale = 1;
        GameObject.Destroy(quizTrigger);
        //SaveManager.instance.coin += 5;
    }

    public void WrongAnswer()
    {
        //wrongText.SetActive(true);

        //IEnumerator ActivateAndDeactivate()
        //{
        //    yield return new WaitForSeconds(textDuration);
        //    wrongText.SetActive(false);
        //}

        quizPanel.SetActive(false);
        Time.timeScale = 1;
        GameObject.Destroy(quizTrigger);

    }
}