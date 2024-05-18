using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    public GameObject quizPanel;
    public Transform player;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            quizPanel.SetActive(true);
            Time.timeScale = 0;
            
        }
    }
}
