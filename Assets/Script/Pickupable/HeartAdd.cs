using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartAdd : MonoBehaviour
{
    [Header("Heart Setting")]
    public int healValue;

    [Header("Audio Clip")]
    [SerializeField] AudioClip heartSound;

    private void Awake()
    {
        // Anda dapat menambahkan logika inisialisasi di sini jika diperlukan
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerStatus playerStatus = collision.GetComponent<PlayerStatus>();
            if (playerStatus != null && playerStatus.gameObject.activeInHierarchy)
            {
                if (playerStatus.currHealth < playerStatus.maxHealth)
                {
                    playerStatus.currHealth += healValue;
                    AudioManager.instance.PlaySound(heartSound);
                    Destroy(gameObject);
                }
            }
        }
    }
}
