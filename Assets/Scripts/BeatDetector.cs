using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeatDetector : MonoBehaviour
{
    public static event Action<float, float> BeatDetection;
    public AudioSource audioSource;
    [SerializeField] private float threshold = 0.4f;
    [SerializeField] private float detectStepTime = 0.5f;
    private float[] spectrum = new float[64];
    private float timer = 0f;

    void Start()
    {

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= detectStepTime)
        {
            timer = 0f;
            audioSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
            float sum = 0f;
            foreach (float f in spectrum)
                sum += f;

            if (sum > threshold)
            {
                BeatDetection?.Invoke(sum, threshold);
            }
        }

        if (!audioSource.isPlaying && !GameManager.GameIsOver)
        {
            Debug.Log("Song end!");
            GameManager.Instance.CompleteSong();
        }
    }
}
