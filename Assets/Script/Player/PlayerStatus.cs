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
    private PlayerController playerController; // Reference to PlayerController script
    private Rigidbody2D rb;

    // Array of components to disable when player dies
    [Header("Components")]
    public Component[] components;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        anim = GetComponent<Animator>();
        currTimer = timerHurt;
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
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

    public void Die()
    {
        anim.SetTrigger("dead");
        anim.SetBool("isDead", true);
        playerController.enabled = false;
        
        rb.position = new Vector3(0, 0, 0);
        //foreach (Component component in components)
        //{
        //    if (component != this && component is Behaviour)
        //    {
        //        ((Behaviour)component).enabled = false;
        //    }
        //}

        //Pemanggilan respawn pada checkpoint saat pemain mati
        //Checkpoint checkpointManager = FindObjectOfType<Checkpoint>();
        // if (checkpointManager == null)
        // {
        //     checkpointManager.RespawnCheck();
        // }
        // else
        // {

        // }
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
    public void Respawn()
    {
        currHealth = maxHealth;
        anim.ResetTrigger("dead");
        anim.SetBool("isDead", false);
        anim.Play("Movement");
        playerController.enabled = true;

        
        //foreach (Component component in components)
        //{
        //    if (component != this && component is Behaviour)
        //    {
        //        ((Behaviour)component).enabled = true;
        //    }
        //}

    }
}
