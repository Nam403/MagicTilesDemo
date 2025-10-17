using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    [SerializeField] float initCountDown = 1f;
    [SerializeField] float spawnStepTime = 0.7f;
    [SerializeField] Tile tilePrefab;
    [SerializeField] float xStep = 2.3f;
    [SerializeField] private Vector3 initTilePosition = new(-3.45f, 12f, 0);
    Vector3 stepVector = new Vector3(1f, 0f, 0f);
    int randomId;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one Spawner in scene!");
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(initCountDown);
        while (true)
        {
            randomId = Random.Range(0, 4);
            SpawnTile(randomId);
            yield return new WaitForSeconds(spawnStepTime);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTile(int columnIndex)
    {
        Instantiate(tilePrefab, initTilePosition + stepVector * xStep * columnIndex, Quaternion.identity);
    }
}
