using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    public int maxHealth;
    public int currHealth;

    public int damage;

    public int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       Health();
        Score();
    }
    void Die()
    {
        // Pemanggilan respawn pada checkpoint saat pemain mati
        Checkpoint checkpointManager = FindObjectOfType<Checkpoint>();
        if (checkpointManager != null)
        {
            checkpointManager.RespawnPlayer();
        }
        else
        {
            Debug.LogError("CheckpointManager tidak ditemukan!");
        }
    }
    public void Health()
    {
        healthText.text ="Health: " + currHealth.ToString();
        if (currHealth == 0)
        {
            Die();
        }
    }

    public void Score()
    {
        scoreText.text = "Score: " + score.ToString();
    }
    public void ResetHealth()
    {
        currHealth = maxHealth;
    }
}
