using UnityEngine;

public class ButtonMoving : MonoBehaviour
{
    public GameObject Button; // Reference to the GameObject you want to rotate

    void Start()
    {
        // Rotate around the local Z-axis (forward axis) with a duration of 1 second and looping infinitely
        LeanTween.rotateAroundLocal(Button, Vector3.forward, 16f, 1f).setEase(LeanTweenType.easeOutCubic).setLoopType(LeanTweenType.pingPong);
    }
}
