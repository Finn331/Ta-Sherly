using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public GameObject quizPanel;
    public LevelsManager levelsManager;
    public PlayerController playerController;
    public PlayerController playerController2;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            quizPanel.SetActive(true);
            Time.timeScale = 0;
            levelsManager.isPaused = true;
            playerController.enabled = false;
            playerController2.enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
