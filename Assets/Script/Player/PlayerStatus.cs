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

    private Animator anim;
    private float timerHurt = 1f;
    private float currTimer;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        anim = GetComponent<Animator>();
        currTimer = timerHurt;
    }

    // Update is called once per frame
    void Update()
    {
        currTimer += Time.deltaTime;
       Health();
        Score();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            currHealth -= 1;
            anim.SetTrigger("hurt");
            if(currTimer == 1)
            {
                currHealth -= 1;
                anim.SetTrigger("hurt");
            }
        }
    }

    void Die()
    {
        //// Pemanggilan respawn pada checkpoint saat pemain mati
        //Checkpoint checkpointManager = FindObjectOfType<Checkpoint>();
        //if (checkpointManager != null)
        //{
        //    checkpointManager.RespawnPlayer();
        //}
        //else
        //{
        //    Debug.LogError("CheckpointManager tidak ditemukan!");
        //}
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
