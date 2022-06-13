using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCinemachineFeedback : Feedback
{
    [SerializeField]
    private CinemachineVirtualCamera _cinemachineCamera;
    [SerializeField]
    [Range(0, 5)]
    private float _amplitude = 1, _intensity = 1;
    [SerializeField]
    [Range (0, 1)]
    private float _duration = 0.1f;

    private CinemachineBasicMultiChannelPerlin _noise;

    private void Start()
    {
        if (_cinemachineCamera == null)
        {
            _cinemachineCamera = FindObjectOfType<CinemachineVirtualCamera>();
        }

        _noise = _cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public override void CompletePreviousFeedBack()
    {
        StopAllCoroutines();
        _noise.m_AmplitudeGain = 0;
    }

    public override void CreateFeedBack()
    {
        _noise.m_AmplitudeGain = _amplitude;
        _noise.m_FrequencyGain = _intensity;
        StartCoroutine(ShakeCoroutine());
    }

    IEnumerator ShakeCoroutine()
    {
        for (float i = _duration; i > 0; i -= Time.deltaTime)
        {
            _noise.m_AmplitudeGain = Mathf.Lerp(0, _amplitude, i / _duration);
            yield return null;
        }
        _noise.m_AmplitudeGain = 0;
    }
}
