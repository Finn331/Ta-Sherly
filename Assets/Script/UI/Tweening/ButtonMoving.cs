using UnityEngine;

public class ButtonMoving : MonoBehaviour
{
    [Header("Button Setup")]
    public GameObject Button; // Reference to the GameObject you want to rotate
    public float delaySpeed;
    [SerializeField] LeanTweenType tweenType;
    void Start()
    {
        // Rotate around the local Z-axis from -4 to 4 degrees
        LeanTween.value(gameObject, UpdateRotation, -4f, 4f, delaySpeed).setEase(tweenType).setLoopPingPong();
    }

    void UpdateRotation(float zRotation)
    {
        Button.transform.localRotation = Quaternion.Euler(0, 0, zRotation);
    }
}