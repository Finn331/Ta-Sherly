using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Script Reference")]
    public EnemyPatrol enemyPatrol;
    public AIPath aiPath;
    public AIDestinationSetter aidestinationSetter;

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
        if (collision.gameObject.CompareTag("Player"))
        {
            enemyPatrol.enabled = false;
            aiPath.enabled = true;
            aidestinationSetter.enabled = true;
        }
    }
}
