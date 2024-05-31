using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private PlayerStatus playerStatus;
    private Animator anim;

    [Header("Script Reference")]
    public LevelsManager levelsManager;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        // Memastikan playerStatus ditemukan pada GameObject yang benar
        playerStatus = FindObjectOfType<PlayerStatus>();
        if (playerStatus == null)
        {
            Debug.LogError("PlayerStatus tidak ditemukan dalam scene!");
        }
    }

    public void RespawnCheck()
    {
        if (currentCheckpoint == null)
        {
            Debug.LogWarning("currentCheckpoint masih null, memanggil Die pada playerStatus");
            playerStatus.Die();
            levelsManager.GameOver();
            playerStatus.DisableSprite();
            //Animation();
            //playerStatus.TakeDamage();
            return; // Menghentikan eksekusi untuk mencegah kesalahan lebih lanjut
        }

        playerStatus.Respawn();
        transform.position = currentCheckpoint.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
            //SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("triggered");
        }
    }

    //IEnumerator AnimationCheck()
    //{
    //    yield return new WaitForSeconds(1);
    //    levelsManager.GameOver();

    //}
}
