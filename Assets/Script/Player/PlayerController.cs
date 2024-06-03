using UnityEngine;
using System.Collections;   

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float sprintSpeed; // Speed when sprinting
    public float speed; // Current speed
    public float jumpingPower;
    public float wallCheckDistance;

    private float defaultSpeed; // Default speed
    private float horizontal;
    private bool isFacingRight = true;

    private bool isSprinting; // Added variable to track sprinting state

    private int jumpsRemaining; // Number of jumps remaining

    [Header("Components")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private AudioSource footstepAudioSource;
    [SerializeField] private AudioClip[] footstepSounds; // Array of footstep sounds


    private Animator anim;
    private bool isPlayingFootstep;

    private void Start()
    {
        defaultSpeed = speed;
        jumpsRemaining = 2; // Initialize the number of jumps remaining to 2

        // Component Reference for private variables
        anim = GetComponent<Animator>();
        footstepAudioSource = GetComponent<AudioSource>();
        isPlayingFootstep = false;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) // Check if "Shift" key is pressed
        {
            isSprinting = true;
            speed = sprintSpeed; // Set the speed to sprint speed
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) // Check if "Shift" key is released
        {
            isSprinting = false;
            speed = defaultSpeed; // Set the speed back to default
        }

        // Play footstep sound if the player is moving and grounded
        if (Mathf.Abs(horizontal) > 0 && IsGrounded() && !isPlayingFootstep)
        {
            StartCoroutine(PlayFootstepSound());
        }
    }

    private void FixedUpdate()
    {
        // Move the player horizontally
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

        anim.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        anim.SetBool("isGrounded", IsGrounded());

        // Set isMoving to true when the player is moving
        if (Mathf.Abs(horizontal) > 0)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }

        // Check if facing a wall, then play idle animation
        if (IsFacingWall())
        {
            anim.SetFloat("xVelocity", 0f);
        }

        Flip();
    }

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpsRemaining = 1; // Reset jumps remaining when grounded
            anim.SetTrigger("jump");
        }
        else if (jumpsRemaining > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpsRemaining--; // Decrease jumps remaining when performing a double jump
            anim.SetTrigger("jump");
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool IsFacingWall()
    {
        float direction = isFacingRight ? 1f : -1f;
        Vector2 rayOrigin = new Vector2(wallCheck.position.x, wallCheck.position.y);
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.right * direction, wallCheckDistance, wallLayer); // Change groundLayer to wallLayer

        // Return true if there's a wall in front
        return hit.collider != null;
    }

    public bool canAttack()
    {
        return horizontal == 0 && IsGrounded();
    }

    private IEnumerator PlayFootstepSound()
    {
        isPlayingFootstep = true;
        while (Mathf.Abs(horizontal) > 0 && IsGrounded())
        {
            AudioClip footstep = footstepSounds[Random.Range(0, footstepSounds.Length)];
            footstepAudioSource.PlayOneShot(footstep);
            yield return new WaitForSeconds(footstep.length);
        }
        isPlayingFootstep = false;
    }
}
