using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (hit) return;

        // Track the projectile's lifetime
        lifetime += Time.deltaTime;
        if (lifetime > 5) Deactivate();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Wall") ||
            collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Obstacle"))
        {
            HandleCollision();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") ||
            collision.gameObject.CompareTag("Wall") ||
            collision.gameObject.CompareTag("Ground") ||
            collision.gameObject.CompareTag("Obstacle"))
        {
            HandleCollision();
        }
    }

    private void HandleCollision()
    {
        if (hit) return;

        hit = true;
        anim.SetTrigger("explode");
        boxCollider.enabled = false;
        rb.velocity = Vector2.zero; // Stop the projectile movement
    }

    // Called by an animation event at the end of the explosion animation
    public void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        // Adjust the projectile's scale based on the direction
        float localScaleX = Mathf.Abs(transform.localScale.x) * Mathf.Sign(_direction);
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

        // Apply force to the Rigidbody2D
        rb.velocity = Vector2.zero; // Reset velocity to prevent accumulation of forces
        rb.AddForce(new Vector2(speed * direction, 0), ForceMode2D.Impulse);
    }
}
