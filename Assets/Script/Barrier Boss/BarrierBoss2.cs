using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierBoss2 : MonoBehaviour
{
    [Header("Boss Arena Barrier")]
    [SerializeField] GameObject barrier;
    [SerializeField] GameObject barrier2;

    [Header("Script Reference")]
    [SerializeField] GameObject boss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (barrier != null)
            {
                barrier.SetActive(true);
                boss.SetActive(true);
            }
        }
    }
}
