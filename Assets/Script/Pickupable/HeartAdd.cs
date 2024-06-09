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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerStatus.currHealth += healValue;
            AudioManager.instance.PlaySound(heartSound);
        }
    }
}
