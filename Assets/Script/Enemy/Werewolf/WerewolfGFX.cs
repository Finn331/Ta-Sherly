using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WerewolfGFX : MonoBehaviour
{
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

        anim.SetBool("moving", isMoving);
    }

    void DeactivateEnemy()
    {
        gameObject.SetActive(false);
    }
}
