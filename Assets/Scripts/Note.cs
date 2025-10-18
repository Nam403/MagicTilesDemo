using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private Vector3 targetScale = new Vector3(0.6f, 0.6f, 1f);
    [SerializeField] private float duration = 0.5f;
    private float scaleFactor = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable() => BeatDetector.BeatDetection += BeatHandle;
    void OnDisable() => BeatDetector.BeatDetection -= BeatHandle;

    public void BeatHandle(float sum, float threshold)
    {
        scaleFactor = 1f + sum / threshold / 5;
        StartCoroutine(ScaleOverTime(targetScale * scaleFactor, duration));
    }

    IEnumerator ScaleOverTime(Vector3 newScale, float time)
    {
        Vector3 originalScale = transform.localScale;
        float elapsed = 0f;

        while (elapsed < time)
        {
            transform.localScale = Vector3.Lerp(originalScale, newScale, elapsed / time);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = newScale;
    }
}
