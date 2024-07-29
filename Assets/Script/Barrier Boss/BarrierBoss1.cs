using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBoss1 : MonoBehaviour
{
    [Header("Boss Arena Barrier")]
    [SerializeField] GameObject barrier2;

    [Header("Script Reference")]
    [SerializeField] AIDestinationSetter destinationSetter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (barrier2 != null)
            {
                barrier2.SetActive(false);
                destinationSetter.enabled = false;
            }
        }
    }
}
