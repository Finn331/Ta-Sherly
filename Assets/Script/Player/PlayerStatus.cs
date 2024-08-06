using System.Collections;
using UnityEngine;
using TMPro;

public class PlayerStatus : MonoBehaviour
{
    [Header("Player Status")]
    public int maxHealth;
    public int currHealth;
    public int damage;
    private bool dead;

    private Animator anim;
    private float timerHurt = 1f;
    private float currTimer;
    private PlayerController playerController; // Reference to PlayerController script
    private Rigidbody2D rb;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    private bool invulnerable;

    [Header("Components")]
    public Component[] components;


    [Header("Score Setting")]
    public TextMeshProUGUI scoreText;
    public int score;

    [Header("Audio Clip")]
    public AudioClip hurtSound;
    public AudioClip dieSound;
    public AudioClip respawnSound;
    public AudioClip ashLava;

    void Awake()
    {
        currHealth = maxHealth;
        anim = GetComponent<Animator>();
        currTimer = timerHurt;
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
        spriteRend = GetComponent<SpriteRenderer>();
        //score = PlayerPrefs.GetInt("Score", 0);
    }

    void Update()
    {
        currTimer += Time.deltaTime;
        Health();
        Score();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") && !invulnerable)
        {
            TakeDamage(1);
        }

        if (collision.gameObject.CompareTag("Lava"))
        {
            AudioManager.instance.PlaySound(ashLava);
            currHealth = 0;
        }
    }

    public void Die()
    {
        anim.SetTrigger("dead");
        anim.SetBool("isDead", true);
        anim.SetBool("isMoving", false);
        anim.SetBool("isGrounded", false);
        anim.SetBool("isAttack", false);

        playerController.enabled = false;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;

        foreach (Component component in components)
        {
            if (component != this && component is Behaviour)
            {
                ((Behaviour)component).enabled = false;
            }
        }
    }

    public void TakeDamage(float _damage)
    {
        if (invulnerable) return;
        currHealth = (int)Mathf.Clamp(currHealth - _damage, 0, maxHealth);

        if (currHealth > 0)
        {
            anim.SetTrigger("hurt");
            AudioManager.instance.PlaySound(hurtSound);
            StartCoroutine(Invunerability());
            
        }
        else
        {
            if (!dead)
            {
                Die();
                dead = true;
            }
        }
    }

    public void TakeDamage2(float _damage)
    {
        if (invulnerable) return;
        currHealth = (int)Mathf.Clamp(currHealth - _damage, 0, maxHealth);

        if (currHealth > 0)
        {
            anim.SetTrigger("hurt2");
            AudioManager.instance.PlaySound(hurtSound);
            StartCoroutine(Invunerability());
            
        }
        else
        {
            if (!dead)
            {
                Die();
                dead = true;
            }
        }
    }

    public void Health()
    {
        if (currHealth == 0 && !dead)
        {
            Die();
            dead = true;
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
        playerController.enabled = true;
        rb.isKinematic = false;
        dead = false;
        EnableSprite();
        AudioManager.instance.PlaySound(respawnSound);
        StartCoroutine(Invunerability());

        foreach (Component component in components)
        {
            if (component != this && component is Behaviour)
            {
                ((Behaviour)component).enabled = true;
            }
        }
    }

    public void DisableSprite()
    {
        spriteRend.enabled = false;
    }

    public void EnableSprite()
    {
        spriteRend.enabled = true;
    }

    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
        invulnerable = false;
    }

    // Add this method to increase the score
    public void AddScore(int amount)
    {
        score += amount;
        Score(); // Update the score display
    }
}