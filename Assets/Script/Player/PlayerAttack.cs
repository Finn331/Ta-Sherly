using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;
    [SerializeField] private AudioClip fireballSound;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    public bool isMoving;

    private Animator anim;
    private PlayerController playerMovement;
    private float cooldownTimer = Mathf.Infinity;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (IsGrounded())
        {
            anim.SetBool("isGrounded", true);

            //if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown/* && playerMovement.canAttack()*/
            //    && Time.timeScale > 0)
            //{
            //    Attack();
            //    //anim.SetTrigger("attack");
                
            //}

            if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && Time.timeScale > 0 && isMoving)
            {
                MoveAttack();
            }
            else if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && Time.timeScale > 0 && !isMoving)
            {
                Attack();
            }
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        AudioManager.instance.PlaySound(fireballSound);
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer);

    }

    private void MoveAttack()
    {
        anim.SetTrigger("moveAttack");
        
        AudioManager.instance.PlaySound(fireballSound);
        cooldownTimer = 0;

        fireballs[FindFireball()].transform.position = firePoint.position;
        fireballs[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }
}