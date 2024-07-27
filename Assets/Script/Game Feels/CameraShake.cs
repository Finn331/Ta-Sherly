using System.Collections;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    [Header("Camera Shake Setting")]
    public float shakeIntensity = 1.0f;
    public float shakeTime = 0.5f;
    private float timer = 0f;

    private void Awake()
    {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        _cbmcp = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    void Start()
    {
        StopShake();
    }

    void Update()
    {
        if (Time.timeScale > 0 && timer > 0)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                StopShake();
            }
        }
    }

    public void ShakeCamera(float intensity = -1f, float time = -1f)
    {
        if (intensity >= 0)
        {
            shakeIntensity = intensity;
        }

        if (time >= 0)
        {
            shakeTime = time;
        }

        _cbmcp.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
    }

    public void StopShake()
    {
        _cbmcp.m_AmplitudeGain = 0;
        timer = 0;
    }
}
