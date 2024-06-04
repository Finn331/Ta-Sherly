using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{
    [Header("Player Status Script")]
    public PlayerStatus playerStatus;

    [Header("Audio Clip")]
    public AudioClip coinSound;

    void Start()
    {
        // Attempt to find the PlayerStatus script on the player GameObject
        if (playerStatus == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerStatus = player.GetComponent<PlayerStatus>();
            }
        }

        // Check if playerStatus was successfully found
        if (playerStatus == null)
        {
            Debug.LogError("PlayerStatus script not found on the Player GameObject. Please assign it in the Inspector.");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (playerStatus != null)
            {
                playerStatus.score += 1;
                AudioManager.instance.PlaySound(coinSound);
            }
            else
            {
                Debug.LogError("PlayerStatus reference is missing.");
            }
            Destroy(gameObject);
        }
    }
}
