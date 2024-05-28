using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatTrigger : MonoBehaviour
{
    public GameObject[] bats; // Array to hold bat GameObjects

    void Start()
    {
        // Initialization code if needed
    }

    void Update()
    {
        // Update code if needed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            foreach (GameObject bat in bats)
            {
                if (bat != null)
                {
                    bat.SetActive(true); // Enable the entire GameObject
                }
                else
                {
                    Debug.LogWarning("A GameObject in the bats array is null");
                }
            }
            Destroy(gameObject); // Destroy the trigger GameObject
        }
    }
}
