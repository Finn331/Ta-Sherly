using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 0f, -10f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;
    public float yOffset = 1f;

    private Transform player1;
    private Transform player2;

    void Start()
    {
        // Inisialisasi player1 dan player2
        GameObject player1Object = GameObject.Find("Player");
        if (player1Object != null)
        {
            player1 = player1Object.transform;
        }
        else
        {
            Debug.LogError("Player tidak ditemukan di hierarki dengan nama 'Player'");
        }

        GameObject player2Object = GameObject.Find("Player2");
        if (player2Object != null)
        {
            player2 = player2Object.transform;
        }
        else
        {
            Debug.LogError("Player 2 tidak ditemukan di hierarki dengan nama 'Player2'");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Mengikuti player yang aktif
        if (player1 != null && player1.gameObject.activeSelf)
        {
            FollowPlayer(player1);
        }
        else if (player2 != null && player2.gameObject.activeSelf)
        {
            FollowPlayer(player2);
        }
        else
        {
            Debug.LogWarning("Tidak ada player yang aktif untuk diikuti");
        }
    }

    private void FollowPlayer(Transform target)
    {
        Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
