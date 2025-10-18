using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public static event Action<Vector3> TileTap;

    [SerializeField] float speed = 10f;
    [SerializeField] Sprite clickSprite;
    [SerializeField] float clickDelayTime = 0.25f;
    Vector3 destinationPosition = new(0f, -24f, 0f);
    Vector3 currentPosition;

    // Start is called before the first frame update
    void Start()
    {
        destinationPosition += GetComponent<Transform>().position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = GetComponent<Transform>().position;
        currentPosition = Vector3.MoveTowards(currentPosition, destinationPosition, speed * Time.deltaTime);
        GetComponent<Transform>().position = currentPosition;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Click");
        TileTap?.Invoke(transform.position);
        StartCoroutine(TapFeedbackAndDestroy());
    }

    IEnumerator TapFeedbackAndDestroy()
    {
        // Change Color
        SpriteRenderer rend = GetComponent<SpriteRenderer>();
        if (rend != null)
        {
            rend.sprite = clickSprite;
        }

        // Fading effect
        Vector3 originalScale = transform.localScale;
        Color startColor = GetComponent<SpriteRenderer>().color;
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

        // Destroy object
        Destroy(gameObject);
    }
}
