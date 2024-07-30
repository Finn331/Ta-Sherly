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
    [SerializeField] LevelManager2 levelManager2;
    [SerializeField] LevelManager3 levelManager3;

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
            if (levelsManager != null)
            {
                levelsManager.GameOver();
            }
            if (levelManager2 != null)
            {
                levelManager2.GameOver();
            }
            if (levelManager3 != null)
            {
                levelManager3.GameOver();
            }
            playerStatus.DisableSprite();
            return; // Stop execution to prevent further errors
        }

        playerStatus.Respawn();
        transform.position = currentCheckpoint.position;       
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
}
