using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private float speed = 10f;
    private Vector3 destinationPosition = new(0f, -24f, 0f);
    private Vector3 currentPosition;

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
        ScoreManager.Instance.UpdateScore(1);
        Destroy(gameObject);
    }
}
