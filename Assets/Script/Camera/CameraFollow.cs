using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f; // Speed at which the camera follows the player
    public Vector3 offset; // Offset of the camera from the player

    private Transform player1;
    private Transform player2;

    private void Start()
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

    private void FixedUpdate()
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
        // Calculate the desired position of the camera
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
