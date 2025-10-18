using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEffect : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float clickDelayTime = 0.2f;
    Vector3 stepVector = new(0f, -1f, 0f);
    Vector3 currentPosition;

    Vector3 originalScale;
    Color startColor;

    void Awake()
    {
        originalScale = transform.localScale;
        startColor = GetComponent<SpriteRenderer>().color;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = originalScale;
        GetComponent<SpriteRenderer>().color = startColor;
        StartCoroutine(TapFeedbackAndDisable());
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        transform.position = currentPosition + stepVector * speed * Time.deltaTime;
    }

    IEnumerator TapFeedbackAndDisable()
    {
        // Fading effect
        float startAlpha = startColor.a;
        float time = 0f;
        float alpha;

        while (time < clickDelayTime)
        {
            transform.localScale = Vector3.Lerp(originalScale, originalScale * 1.2f, time / clickDelayTime);
            alpha = Mathf.Lerp(startAlpha, 0f, time / clickDelayTime);
            GetComponent<SpriteRenderer>().color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            time += Time.deltaTime;
            yield return null;
        }

        //Disable effect
        PoolManager.Instance.ReturnEffect(gameObject);
    }
}
