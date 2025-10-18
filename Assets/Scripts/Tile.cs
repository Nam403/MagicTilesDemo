using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public static event Action<GameObject> TileTap;

    [SerializeField] float speed = 10f;
    Vector3 stepVector = new(0f, -1f, 0f);
    Vector3 currentPosition;

    // Update is called once per frame
    void Update()
    {
        currentPosition = transform.position;
        transform.position = currentPosition + stepVector * speed * Time.deltaTime;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Tap");
        TileTap?.Invoke(gameObject);
    }
}
