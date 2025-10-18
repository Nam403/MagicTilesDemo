using UnityEngine;
using System;

public class Border : MonoBehaviour
{
    public static event Action GameOver;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Tile"))
        {
            Debug.Log("Game Over");
            GameOver?.Invoke();
            PoolManager.Instance.ReturnObject(collider.gameObject);
        }
    }
}
