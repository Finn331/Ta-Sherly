using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject interactButton;
    public GameObject teleportTargetB;
    public GameObject cameraObject;  // Referensi ke GameObject Kamera
    public GameObject cameraObject2;

    private bool canTeleport = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Teleport function
    private void TeleportToB()
    {
        if (teleportTargetB != null)
        {
            // Teleport the player to the position of GameObject B
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = teleportTargetB.transform.position;

                // Optionally, you can perform additional actions after teleportation
                // For example, reset velocity or play a teleportation sound
            }
            else
            {
                Debug.LogWarning("Player not found!");
            }
        }
        else
        {
            Debug.LogWarning("Teleport target B is not assigned!");
        }
    }

    private void MoveCamera()
    {
        //// Move the camera to the specified position
        //if (cameraObject != null)
        //{
        //    Vector3 newCameraPosition = cameraObject.transform.position;
        //    newCameraPosition.y = -10.84f;
        //    cameraObject.transform.position = newCameraPosition;
        //}
        //else
        //{
        //    Debug.LogWarning("Camera object not assigned!");
        //}
        cameraObject.SetActive(false);
        cameraObject2.SetActive(true);
        if (cameraObject == null)
        {
            Debug.LogWarning("Camera object not assigned!");
        }

        if (cameraObject2 == null)
        {
            Debug.LogWarning("Camera object not assigned!");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactButton.SetActive(true);
            LeanTween.scale(interactButton, new Vector3(1, 1, 1), 1f).setEase(LeanTweenType.easeOutBack);
            canTeleport = true;
            anim.SetTrigger("open");
            anim.SetBool("isOpen", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            interactButton.SetActive(false);
            LeanTween.scale(interactButton, new Vector3(0, 0, 0), 1f).setEase(LeanTweenType.easeOutBack);
            canTeleport = false;
            anim.SetBool("isOpen", false);
        }
    }

    private void Update()
    {
        // Check for "E" key press in the Update method
        if (canTeleport && Input.GetKeyDown(KeyCode.E))
        {
            TeleportToB();
            MoveCamera(); // Pindahkan kamera hanya ketika tombol "E" ditekan
            Debug.Log("teleport ke " + name);
        }
    }
}
