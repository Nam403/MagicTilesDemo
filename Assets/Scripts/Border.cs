using UnityEngine;
using System;

public class Border : MonoBehaviour
{
    public static event Action GameOver;

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
            GameOver?.Invoke();
            Destroy(collider.gameObject);
        }
    }
}
