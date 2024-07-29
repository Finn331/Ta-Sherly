using System.Collections;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [Header("Enemy Properties")]
    public int maxHealth;
    public Animator anim;
    public Component[] components;

    [Header("Enemy Debug")]
    public int currHealth;

    private bool isDead = false;

    private void Awake()
    {
        currHealth = maxHealth;
    }
    private void Start()
    {
        currHealth = maxHealth;
    }

    // Seril Nub

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Hurt();
        }
    }

    void Hurt()
    {
        if (isDead) return;

        currHealth -= 1;
        anim.SetTrigger("hurt");

        if (currHealth <= 0 && !isDead)
        {
            StartCoroutine(Die());
            anim.SetTrigger("dead");
            anim.SetBool("isDead", true);
        }
    }

    IEnumerator Die()
    {
        isDead = true;
        anim.SetTrigger("dead");
        anim.SetBool("isDead", true);
        anim.SetBool("run", false);
        foreach (Component component in components)
        {
            // Check if the component is a Behaviour (has the enabled property)
            if (component is Behaviour)
            {
                // Cast the component to Behaviour and disable it
                ((Behaviour)component).enabled = false;
            }
            else
            {
                Debug.LogWarning("Component " + component.GetType().Name + " does not have an enabled property.");
            }
        }

        // Wait for the animation to finish
        yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(0).length);

        gameObject.SetActive(false);
    }
}
