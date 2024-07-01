using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AhoolGFX : MonoBehaviour
{
    public AIPath aiPath;

    //private Transform characterTransform;
    //private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //characterTransform = GetComponent<Transform>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
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

        // Assuming you have some condition that determines whether the character should flip or not
        // For example, if the character's x position is less than 0, flip it
        //bool shouldFlip = characterTransform.position.x < 0;

        //// You can replace this condition with whatever logic you have
        //if (shouldFlip)
        //{
        //    FlipCharacter(true); // Flip character horizontally
        //}
        //else
        //{
        //    FlipCharacter(false); // Do not flip character
        //}
    }

    void DeactivateEnemy()
    {
        gameObject.SetActive(false);
    }

    //void FlipCharacter(bool flip)
    //{
    //    // Flip the character by adjusting its scale
    //    if (flip)
    //    {
    //        spriteRenderer.flipX = true; // Flip character horizontally
    //    }
    //    else
    //    {
    //        spriteRenderer.flipX = false; // Do not flip character
    //    }
    //}
}
