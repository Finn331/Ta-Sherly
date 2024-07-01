using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{
    [Header("Audio Clip")]
    public AudioClip coinSound;

    public int coinCount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerStatus playerStatus = collision.GetComponent<PlayerStatus>();
            playerStatus.score += coinCount;
            AudioManager.instance.PlaySound(coinSound);

            Destroy(gameObject);
        }
    }
}
