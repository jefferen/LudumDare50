using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShakeCinemachine : MonoBehaviour
{
    Vector3 OriginPoint, tempoint;
    [Range(1f, 2000f)]
    public float shakeStrength;
    [Range(0.01f, 2)]
    public float time;
    Cinemachine.CinemachineBasicMultiChannelPerlin Cam;

    public void Awake()
    {
        Cam = GameObject.FindGameObjectWithTag("HelpCam").GetComponent<Cinemachine.CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StopTremble();
    }

    public void Shake()
    {
        StartCoroutine(Tremble(time, shakeStrength));
    }

    IEnumerator Tremble(float duration, float magnitude)
    {
        OriginPoint = transform.position;
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            Cam.m_AmplitudeGain = magnitude;
            Cam.m_FrequencyGain = 10;
            yield return new WaitForEndOfFrame();
        }

        transform.position = OriginPoint;
        Quaternion flat = Quaternion.Euler(new Vector3(0, 0, 0));
        transform.rotation = flat;

        StopTremble();
    }

    void StopTremble()
    {
        Cam.m_AmplitudeGain = Cam.m_FrequencyGain = 0;
    }
}
