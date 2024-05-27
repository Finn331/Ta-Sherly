using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private float direction;
    private bool hit;
    private float lifetime;

    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;

        // Move the projectile in a straight line
        transform.Translate(speed * Time.deltaTime * direction, 0, 0);

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
        speed = 0;
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
    }
}
