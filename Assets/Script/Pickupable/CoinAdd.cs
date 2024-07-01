using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class CoinAdd : MonoBehaviour
{
    [Header("Player Status Script")]
    public PlayerStatus playerStatus;

    [Header("Player Prefs Setting")]
    public string currentSceneName;

    [Header("Audio Clip")]
    public AudioClip coinSound;

    private int coinCount = 0;
    private void Awake()
    {
        coinCount = PlayerPrefs.GetInt(currentSceneName, 0);
    }
    void Start()
    {
        //// Attempt to find the PlayerStatus script on the player GameObject
        //if (playerStatus == null)
        //{
        //    GameObject player = GameObject.FindGameObjectWithTag("Player");
        //    if (player != null)
        //    {
        //        playerStatus = player.GetComponent<PlayerStatus>();
        //    }
        //}

        //// Check if playerStatus was successfully found
        //if (playerStatus == null)
        //{
        //    Debug.LogError("PlayerStatus script not found on the Player GameObject. Please assign it in the Inspector.");
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            coinCount++;
            PlayerPrefs.SetInt(currentSceneName, coinCount);
            PlayerPrefs.Save();
            AudioManager.instance.PlaySound(coinSound);

            //if (playerStatus != null)
            //{
               
            //}
            //else
            //{
            //    Debug.LogError("PlayerStatus reference is missing.");
            //}
            Destroy(gameObject);
        }
    }
}
