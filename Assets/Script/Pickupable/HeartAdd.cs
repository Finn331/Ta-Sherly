using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAdd : MonoBehaviour
{
    [Header("Heart Setting")]
    public int healValue;
    [Header("Script Reference")]
    public PlayerStatus playerStatus;

    [Header("Audio Clip")]
    [SerializeField] AudioClip heartSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (playerStatus.currHealth == playerStatus.maxHealth)
            {
                return;
            }
            if (playerStatus.currHealth <= playerStatus.maxHealth)
            {
                Heal();
            }
            
            
        }
    }

    void Heal()
    {
        playerStatus.currHealth += healValue;
        AudioManager.instance.PlaySound(heartSound);
        Destroy(gameObject);
    }
}
