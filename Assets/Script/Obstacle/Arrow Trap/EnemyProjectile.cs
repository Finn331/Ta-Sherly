using UnityEngine;

public class EnemyProjectile : EnemyDamage
{
    [SerializeField] private float speed; // Kecepatan awal panah jatuh
    [SerializeField] private float resetTime; // Waktu reset setelah panah diluncurkan
    private float lifetime; // Waktu yang sudah berlalu sejak panah diluncurkan
    private Rigidbody2D rb;
    private BoxCollider2D coll;

    private bool hit; // Menandakan apakah panah telah mengenai sesuatu

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    public void ActivateProjectile()
    {
        hit = false;
        lifetime = 0;
        gameObject.SetActive(true);
        coll.enabled = true;

        // Berikan gaya ke bawah saat panah diaktifkan
        rb.velocity = Vector2.zero; // Reset velocity
        rb.AddForce(Vector2.down * speed, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if (hit) return;

        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            Deactivate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerStatus>().TakeDamage(damage); // Berikan damage ke pemain
            hit = true;
            Deactivate();
        }
        else if (collision.CompareTag("GroundT"))
        {
            hit = true;
            Deactivate();
        }
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
        coll.enabled = false;
    }
}
