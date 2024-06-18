using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    // PlayerStatus script reference
    private PlayerStatus playerStatus;

    // Healthbar
    public Image[] heart;
    public Image[] emptyHeart;

    private void Start()
    {
        playerStatus = GetComponent<PlayerStatus>();
    }

    private void Update()
    {
        Healthbars();
    }

    void Healthbars()
    {
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < playerStatus.currHealth)
            {
                heart[i].enabled = true;
                emptyHeart[i].enabled = false;
            }
            else
            {
                heart[i].enabled = false;
                emptyHeart[i].enabled = true;
            }
        }
    }
}
