using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private PlayerStatus playerStatus;
    private Animator anim;
    private int checkpointCounter = 0; // Tracks the number of checkpoints triggered

    [Header("Script Reference")]
    public LevelsManager levelsManager;

    [Header("Camera Setting")]
    public GameObject cameraA;
    public GameObject cameraB;

    private void Awake()
    {
        checkpointCounter = 0;
        anim = GetComponent<Animator>();
        playerStatus = FindObjectOfType<PlayerStatus>();
        if (playerStatus == null)
        {
            Debug.LogError("PlayerStatus not found in the scene!");
        }
    }

    public void RespawnCheck()
    {
        if (currentCheckpoint == null)
        {
            Debug.LogWarning("currentCheckpoint is null, calling Die on playerStatus");
            playerStatus.Die();
            levelsManager.GameOver();
            playerStatus.DisableSprite();
            return; // Stop execution to prevent further errors
        }

        playerStatus.Respawn();
        transform.position = currentCheckpoint.position;

        // Camera logic based on checkpointCounter
        if (checkpointCounter > 1) // Camera B activates after second checkpoint
        {
            ActivateCameraB();
        }
        else if (checkpointCounter == 1)
        {
            ActivateCameraA();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
            checkpointCounter++; // Increase checkpointCounter when a checkpoint is triggered
            // SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("triggered");
        }
    }

    private void ActivateCameraA()
    {
        cameraB.SetActive(false);
        cameraA.SetActive(true);
    }

    private void ActivateCameraB()
    {
        cameraA.SetActive(false);
        cameraB.SetActive(true);
    }
}
