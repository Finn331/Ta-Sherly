using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Vector3 respawnPoint;
    private PlayerStatus playerStatus;

    void Start()
    {
        // Mendapatkan posisi checkpoint saat ini
        respawnPoint = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Menyimpan posisi checkpoint saat player bercollide dengan checkpoint
            respawnPoint = transform.position;
        }
    }

    public void RespawnPlayer()
    {
        // Mengatur posisi pemain ke posisi checkpoint terakhir dan mengisi kembali kesehatannya
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = respawnPoint;
        playerStatus = player.GetComponent<PlayerStatus>();
        if (playerStatus != null)
        {
            playerStatus.ResetHealth();
        }
    }
}
