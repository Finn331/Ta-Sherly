using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HeaderTweening : MonoBehaviour
{
    [Header("Header Setup")]
    public GameObject headerObject;
    [SerializeField] private float delaySpeed = 1f;
    [SerializeField] private LeanTweenType tweenType;

    private void Start()
    {
        // Start the scaling animation
        StartScalingAnimation();
    }

    private void StartScalingAnimation()
    {
        LeanTween.scale(headerObject, new Vector3(1.1f, 1.1f, 1.1f), delaySpeed).setEase(tweenType).setLoopPingPong();
    }
}
