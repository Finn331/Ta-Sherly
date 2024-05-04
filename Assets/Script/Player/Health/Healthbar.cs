using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // PlayerStatus script reference
    private PlayerStatus playerStatus;
    
    // Healthbar
    public Image[] heart;

    private void Start()
    {
        playerStatus = GameObject.Find("Player").GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        Healthbars();
    }

    void Healthbars()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            // Aktifkan atau nonaktifkan sprite sesuai dengan currentHealth
            heart[i].enabled = i < playerStatus.currHealth;
        }
    }
}