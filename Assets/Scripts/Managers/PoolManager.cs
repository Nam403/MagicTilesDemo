using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance { get; private set; }

    [SerializeField] GameObject objectPrefab;
    [SerializeField] GameObject effectPrefab;
    [SerializeField] int poolSize = 20;

    Queue<GameObject> objectPool = new Queue<GameObject>();
    Queue<GameObject> effectPool = new Queue<GameObject>();

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one PoolManager in scene!");
            return;
        }
        Instance = this;
    }
    void OnEnable()
    {
        Tile.TileTap += ReturnObject;
        Tile.TileTap += SetEffect;
    }

    void OnDisable()
    {
        Tile.TileTap -= ReturnObject;
        Tile.TileTap -= SetEffect;
    }

    /*void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject effect = Instantiate(effectPrefab);
            effect.SetActive(false);
            effectPool.Enqueue(effect);
        }
    }*/

    public GameObject GetObject()
    {
        if (objectPool.Count > 0)
        {
            GameObject obj = objectPool.Dequeue();
            obj.SetActive(true);
            return obj;
        }

        // Create new object
        return Instantiate(objectPrefab);
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        objectPool.Enqueue(obj);
    }

    public void SetEffect(GameObject obj)
    {
        GameObject effect;
        if (effectPool.Count > 0)
        {
            effect = effectPool.Dequeue();
            effect.SetActive(true);
        }
        else
        {
            // Create new object
            effect = Instantiate(effectPrefab);
        }
        effect.transform.position = obj.transform.position;
    }

    public void ReturnEffect(GameObject effect)
    {
        effect.SetActive(false);
        effectPool.Enqueue(effect);
    }
}
