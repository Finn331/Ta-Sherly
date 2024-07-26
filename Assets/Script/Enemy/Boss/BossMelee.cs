using Pathfinding;
using UnityEngine;

public class BossMelee : MonoBehaviour
{
    [Header("Attack Parameters")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private float range;
    public int damage;

    [Header("Melee Attack 2 Parameters")]
    [SerializeField] private float meleeAttack2Chance = 0.45f; // 45% chance for melee attack 2
    public int meleeAttack2Damage = 3; // Additional damage for MeleeAttack2
    public bool canUseMeleeAttack2; // Boolean to check if MeleeAttack2 can be used

    [Header("Collider Parameters")]
    [SerializeField] private float colliderDistance;
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("Player Layer")]
    [SerializeField] private LayerMask playerLayer;
    private float cooldownTimer = Mathf.Infinity;

    [Header("Audio Clip")]
    public AudioClip attackSound;

    [Header("Reference")]
    public AIPath aiPath;
    public Animator anim;
    private PlayerStatus playerHealth;
    private EnemyPatrol enemyPatrol;

    private void Awake()
    {
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    private void Update()
    {
        cooldownTimer += Time.deltaTime;

        // Attack only when player in sight
        if (PlayerInSight())
        {
            DisablePath();
            if (cooldownTimer >= attackCooldown)
            {
                cooldownTimer = 0;
                if (canUseMeleeAttack2 && Random.value <= meleeAttack2Chance)
                {
                    MeleeAttack2();
                }
                else
                {
                    MeleeAttack();
                }
            }
        }

        if (!PlayerInSight())
        {
            EnablePath();
        }

        if (enemyPatrol != null)
            enemyPatrol.enabled = !PlayerInSight();
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
            0, Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<PlayerStatus>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
            new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void MeleeAttack2()
    {
        anim.SetTrigger("attack2");
        // Ensure DamagePlayer is called regardless of animation event
        DamagePlayer(meleeAttack2Damage); // Apply additional damage
    }

    private void MeleeAttack()
    {
        anim.SetTrigger("attack");
        // Ensure DamagePlayer is called regardless of animation event
        DamagePlayer();
    }

    private void DamagePlayer(int additionalDamage = 0)
    {
        if (PlayerInSight() && playerHealth != null) // Ensure playerHealth is not null
        {
            playerHealth.TakeDamage(damage + additionalDamage);
            AudioManager.instance.PlaySound(attackSound);
        }
    }


    void DisablePath()
    {
        aiPath.enabled = false;
    }

    void EnablePath()
    {
        aiPath.enabled = true;
    }
}
