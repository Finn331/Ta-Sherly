using UnityEngine;

public class ButtonMoving : MonoBehaviour
{
    public GameObject Button; // Reference to the GameObject you want to rotate

    void Start()
    {
        // Rotate around the local Z-axis from -4 to 4 degrees
        LeanTween.value(gameObject, UpdateRotation, -4f, 4f, 1f).setEase(LeanTweenType.easeOutCubic).setLoopPingPong();
    }

    void UpdateRotation(float zRotation)
    {
        Button.transform.localRotation = Quaternion.Euler(0, 0, zRotation);
    }
}
