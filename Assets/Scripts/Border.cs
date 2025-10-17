using UnityEngine;

public class Border : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Tile"))
        {
            Debug.Log("Game Over");
            GameManager.Instance.EndGame();
            Destroy(collider.gameObject);
        }
    }
}
