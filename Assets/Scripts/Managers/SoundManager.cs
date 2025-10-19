using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    public static event Action<float, float> BeatDetection;
    public static event Action SongEnd;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip goodTapSound;
    [SerializeField] AudioClip missTapSound;
    [SerializeField] AudioClip perfectTapSound;

    [SerializeField] float threshold = 0.4f;
    [SerializeField] float detectStepTime = 0.5f;
    float[] spectrum = new float[64];
    float timer = 0f;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one SoundManager in scene!");
            return;
        }
        Instance = this;
    }

    void OnEnable()
    {
        TimingBar.GoodTap += PlayGoodTapSound;
        TimingBar.MissTap += PlayMissTapSound;
        TimingBar.PerfectTap += PlayPerfectTapSound;
    }
    void OnDisable()
    {
        TimingBar.GoodTap -= PlayGoodTapSound;
        TimingBar.MissTap -= PlayMissTapSound;
        TimingBar.PerfectTap -= PlayPerfectTapSound;
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
            SongEnd?.Invoke();
        }
    }

    void PlayGoodTapSound()
    {
        AudioSource.PlayClipAtPoint(goodTapSound, transform.position);
    }

    void PlayMissTapSound()
    {
        AudioSource.PlayClipAtPoint(missTapSound, transform.position);
    }

    void PlayPerfectTapSound()
    {
        AudioSource.PlayClipAtPoint(perfectTapSound, transform.position);
    }
}
