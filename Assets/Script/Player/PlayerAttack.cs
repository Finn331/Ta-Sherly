using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform spawnPoint;
    public float fireRate = 0.5f;
    public float projectileLifetime = 5f; // Added projectile lifetime
    private float nextFireTime;
    private Animator anim;

    private List<GameObject> pooledProjectiles = new List<GameObject>();
    public int pooledAmount = 20;

    void Start()
    {
        anim = GetComponent<Animator>();

        for (int i = 0; i < pooledAmount; i++)
        {
            GameObject obj = Instantiate(projectilePrefab);
            obj.SetActive(false);
            pooledProjectiles.Add(obj);
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            anim.SetTrigger("attack");
            //anim.SetBool("isFire", true);
            nextFireTime = Time.time + fireRate;
            FireProjectile();
        }

        
    }

    void FireProjectile()
    {
        for (int i = 0; i < pooledProjectiles.Count; i++)
        {
            if (!pooledProjectiles[i].activeInHierarchy)
            {
                pooledProjectiles[i].transform.position = spawnPoint.position;
                pooledProjectiles[i].transform.rotation = spawnPoint.rotation;
                pooledProjectiles[i].SetActive(true);
                StartCoroutine(DeactivateProjectile(pooledProjectiles[i])); // Start coroutine to deactivate projectile
                break;
            }
        }
    }

    IEnumerator DeactivateProjectile(GameObject projectile)
    {
        yield return new WaitForSeconds(projectileLifetime);
        projectile.SetActive(false);
    }
}
