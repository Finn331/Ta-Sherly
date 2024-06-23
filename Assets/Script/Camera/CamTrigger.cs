using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTrigger : MonoBehaviour
{
    [Header("Camera Settings")]
    public float newOffseet;

    [Header("Script Reference")]
    public CameraFollow cameraFollow;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            cameraFollow.offset.x = newOffseet;
        }
        //Destroy(gameObject);
    }
}
