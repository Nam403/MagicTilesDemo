using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] float xStep = 2.3f;
    [SerializeField] Vector3 initTilePosition = new(-3.45f, 12f, 0);
    
    Vector3 stepVector = new Vector3(1f, 0f, 0f);

    void OnEnable() => SoundManager.BeatDetection += SpawnTile;
    void OnDisable() => SoundManager.BeatDetection -= SpawnTile;

    void SpawnTile(float sum, float threshold)
    {
        // Convert threshold to columnIndex (0-3)
        int columnIndex = (int)(sum * 4f / threshold) % 4;
        // Spawn tile using id
        GameObject obj = PoolManager.Instance.GetObject();
        //GameObject obj = Instantiate(prefab);
        obj.transform.position = initTilePosition + stepVector * xStep * columnIndex;
    }
}
