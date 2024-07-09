using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private AudioClip checkpoint;
    private Transform currentCheckpoint;
    private PlayerStatus playerStatus;
    private Animator anim;
    private int checkpointCounter = 0; // Menambahkan integer untuk melacak checkpoint

    [Header("Script Reference")]
    public LevelsManager levelsManager;

    [Header("Camera Setting")]
    public GameObject cameraA;
    public GameObject cameraB;

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
            return; // Menghentikan eksekusi untuk mencegah kesalahan lebih lanjut
        }

        playerStatus.Respawn();
        transform.position = currentCheckpoint.position;

        // Pengecekan nilai checkpoint
        if (checkpointCounter > 1)
        {
            ActivateCameraB();
        }
        else
        {
            MoveCamera();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
            checkpointCounter++; // Meningkatkan nilai checkpointCounter setiap kali checkpoint disentuh
            //SoundManager.instance.PlaySound(checkpoint);
            collision.GetComponent<Collider2D>().enabled = false;
            collision.GetComponent<Animator>().SetTrigger("triggered");
        }
    }

    private void MoveCamera()
    {
        cameraB.SetActive(false);
        cameraA.SetActive(true);
    }

    private void ActivateCameraB()
    {
        cameraA.SetActive(false);
        cameraB.SetActive(true);
    }

    //IEnumerator AnimationCheck()
    //{
    //    yield return new WaitForSeconds(1);
    //    levelsManager.GameOver();
    //}
}
