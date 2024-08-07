using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanGFX : MonoBehaviour
{
    public AIPath aiPath;
    public Rigidbody2D rb;

    private Animator anim;
    
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (aiPath.desiredVelocity.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (aiPath.desiredVelocity.y <= -0.01)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void DeactivateEnemy()
    {
        gameObject.SetActive(false);
    }
}
