using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ScreenShakeController : MonoBehaviour
{
    public static ScreenShakeController Instance;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    public float shakeTimerTotal;
    private float StartingIntensity;

    public void Start()
    {
        Instance = this;
    }

    private void Awake()
    {
       cinemachineVirtualCamera= GetComponent<CinemachineVirtualCamera>();
    }

    public void Shake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        StartingIntensity = intensity;
        shakeTimerTotal = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;

            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = Mathf.Lerp(StartingIntensity, 0f, 1-(shakeTimer / shakeTimerTotal));

            }
        }
        
    }
}
