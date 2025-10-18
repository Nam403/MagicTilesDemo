using System.Collections;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] Vector3 targetScale = new Vector3(0.6f, 0.6f, 1f);
    [SerializeField] float duration = 0.5f;
    float scaleFactor = 1f;

    void OnEnable() => SoundManager.BeatDetection += BeatHandle;
    void OnDisable() => SoundManager.BeatDetection -= BeatHandle;

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
