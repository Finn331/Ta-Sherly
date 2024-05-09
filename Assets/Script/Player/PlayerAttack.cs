using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Assuming Fire1 is your fire button (like left mouse button)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Determine the direction based on the player's facing direction
        Vector2 shootDirection = transform.right; // By default, shoot to the right

        // Check if the player is facing left
        if (transform.localScale.x < 0) // If the local scale's x component is negative, player is facing left
        {
            shootDirection = -transform.right; // Set shoot direction to left
        }

        // Spawn bullet at the firePoint position
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Apply force to the bullet
        rb.AddForce(shootDirection * bulletForce, ForceMode2D.Impulse);
    }
}
