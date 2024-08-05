using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager3 : MonoBehaviour
{
    [Header("Pause Parameter")]
    public GameObject pausePanel;

    [Header("Gameover Parameter")]
    public GameObject gameoverPanel;

    [Header("Boolean Setting")]
    public bool isPaused;
    public bool isGameover;

    // GameObject array to hold player references
    [Header("Player Setting")]
    public GameObject[] players;
    // GameObject to store the initial position
    public GameObject initialPosition;

    [Header("Player Script Reference")]
    [SerializeField] private PlayerController playerController;
    [SerializeField] private PlayerController playerController2;
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerAttack playerAttack2;

    [Header("Audio Source Setting")]
    public AudioSource lavaAudioSource;
    [SerializeField] AudioClip buttonClick;

    [Header("Cinemachine Camera Setup")]
    [SerializeField] GameObject cinemachineCameraP1;
    [SerializeField] GameObject cinemachineCameraP2;

    //[Header("Score Level Setting")]
    //public TextMeshProUGUI scoreText;

    private int character1;
    private int character2;
    private void Awake()
    {
        character1 = PlayerPrefs.GetInt("Character", 1);
        character2 = PlayerPrefs.GetInt("Character", 2);
        if (character1 != 2)
        {
            players[0].SetActive(true);
            if (cinemachineCameraP1 != null)
            {
                cinemachineCameraP1.SetActive(true);
            }
        }
        if (character2 != 1)
        {
            players[1].SetActive(true);
            if (cinemachineCameraP2 != null)
            {
                cinemachineCameraP2.SetActive(true);
            }
        }
        isPaused = false;
        isGameover = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        ////Cursor.visible = true;
        ////Cursor.lockState = CursorLockMode.None;

        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //// Initialize the players array with Player 1 and Player 2
        //players = new GameObject[2];
        //players[0] = GameObject.FindWithTag("Player1");
        //players[1] = GameObject.FindWithTag("Player2");
        //// Find the initial position GameObject
        //initialPosition = GameObject.Find("Initial Position");
    }

    // Update is called once per frame
    void Update()
    {
        //InputCheck();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        isPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        lavaAudioSource.enabled = false;
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        lavaAudioSource.enabled = true;
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameoverPanel.SetActive(true);
        isGameover = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        lavaAudioSource.enabled = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        gameoverPanel.SetActive(false);
        playerController.enabled = true;
        playerController2.enabled = true;
        playerAttack.enabled = true;
        playerAttack2.enabled = true;
        AudioManager.instance.PlaySound(buttonClick);
        // Check if Player 1 or Player 2 is active and reset its position if so
        foreach (GameObject player in players)
        {
            if (player != null && player.activeSelf)
            {
                player.transform.position = initialPosition.transform.position;

                // Re-enable the SpriteRenderer component
                SpriteRenderer spriteRenderer = player.GetComponent<SpriteRenderer>();
                if (spriteRenderer != null)
                {
                    spriteRenderer.enabled = true;
                }
            }
        }

        isGameover = false;
        isPaused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        PlayerReference();
        SceneManager.LoadScene("Level 3");
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Mainmenu");
        AudioManager.instance.PlaySound(buttonClick);
    }

    public void QuitGame()
    {
        AudioManager.instance.PlaySound(buttonClick);
        Application.Quit();
    }

    void PlayerReference()
    {
        // Ambil komponen PlayerController dari player1
        PlayerStatus player1Status = players[0].GetComponent<PlayerStatus>();

        // Ambil komponen PlayerController dari player2
        PlayerStatus player2Status = players[1].GetComponent<PlayerStatus>();

        // Mengambil konmponen Animator dari player
        Animator player1Animator = players[0].GetComponent<Animator>();
        Animator player2Animator = players[1].GetComponent<Animator>();

        player1Status.currHealth = 3;
        player2Status.currHealth = 3;

        player1Animator.SetBool("isDead", false);
        player2Animator.SetBool("isDead", false);
        player1Animator.SetTrigger("idle");
        player2Animator.SetTrigger("idle");
    }

    public IEnumerator DelayActivate()
    {
        yield return new WaitForSeconds(0.5f);
        playerController.enabled = true;
        playerController2.enabled = true;
        playerAttack.enabled = true;
        playerAttack2.enabled = true;
    }
}