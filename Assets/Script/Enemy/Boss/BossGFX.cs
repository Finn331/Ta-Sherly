using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BossGFX : MonoBehaviour
{
    [Header("Reference")]
    [SerializeField] EnemyStatus enemyStatus; // enemyStatus reference
    [SerializeField] BossMelee bossMelee; // meleeEnemyAstar reference

    public GameObject barrier2;
    public GameObject barrier1;
    public AIPath aiPath;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 desiredVelocity = aiPath.desiredVelocity;
        bool isMoving = desiredVelocity.magnitude > 0.01f;

        if (desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (desiredVelocity.x <= -0.01f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetBool("run", isMoving);

        PhaseChange();

        if (enemyStatus.currHealth < 1)
        {
            Destroy(gameObject);
            Destroy(barrier2);
            Destroy(barrier1);
        }
    }

    void DeactivateEnemy()
    {
        Destroy(gameObject);

    }

    void PhaseChange()
    {
        if (enemyStatus.currHealth == 10)
        {
            bossMelee.damage = 1;
            aiPath.maxSpeed = 3;
            bossMelee.canUseMeleeAttack2 = true;
        }
    }
}
