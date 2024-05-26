using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    public Transform characterTransform;
    public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Assuming you have some condition that determines whether the character should flip or not
        // For example, if the character's x position is less than 0, flip it
        //bool shouldFlip = characterTransform.position.x < 9.8;

        ////// You can replace this condition with whatever logic you have
        //if (shouldFlip)
        //{
        //    FlipCharacter(true); // Flip character horizontally
        //}
        //else
        //{
        //    FlipCharacter(false); // Do not flip character
        //}

        if (characterTransform.position.x < 9.8)
        {
            FlipCharacter(true);
        } else if (characterTransform.position.x > 4.6)
        {
            FlipCharacter(true);
        }
    }

    void FlipCharacter(bool flip)
    {
        // Flip the character by adjusting its scale
        if (flip)
        {
            spriteRenderer.flipX = true; // Flip character horizontally
        }
        else
        {
            spriteRenderer.flipX = false; // Do not flip character
        }
    }
}
