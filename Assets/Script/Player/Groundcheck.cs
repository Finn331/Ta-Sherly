using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundcheck : MonoBehaviour
{
    [SerializeField] private Transform raycastOrigin;
    [SerializeField] private Transform playerFeet;
    [SerializeField] private LayerMask groundLayer;

    private RaycastHit2D Hit2D;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundCheck();
    }

    void GroundCheck()
    {
        Hit2D = Physics2D.Raycast(raycastOrigin.position, -Vector2.up, 0.2f, groundLayer);

        if (Hit2D != false)
        {
            if (Hit2D.distance < 0.1f)
            {
                Vector2 temp = playerFeet.position;
                temp.y = Hit2D.point.y;
                playerFeet.position = temp;
            }
        }
    }
}
