using UnityEngine;

public class ButtonMoving : MonoBehaviour
{
    [Header("Button Setup")]
    public GameObject Button; // Reference to the GameObject you want to rotate
    [SerializeField] private float delaySpeed;
    [SerializeField] private float fromPos;
    [SerializeField] private float toPos;
    [SerializeField] LeanTweenType tweenType;

    void Start()
    {
        // Rotate around the local Z-axis from -4 to 4 degrees
        LeanTween.value(gameObject, UpdateRotation, fromPos, toPos, delaySpeed).setEase(tweenType).setLoopPingPong();
    }

    void UpdateRotation(float zRotation)
    {
        Button.transform.localRotation = Quaternion.Euler(0, 0, zRotation);
    }
}