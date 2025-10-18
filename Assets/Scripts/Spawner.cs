using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance;
    [SerializeField] Tile tilePrefab;
    [SerializeField] float xStep = 2.3f;
    [SerializeField] Vector3 initTilePosition = new(-3.45f, 12f, 0);
    
    Vector3 stepVector = new Vector3(1f, 0f, 0f);
    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one Spawner in scene!");
            return;
        }
        Instance = this;
    }

    void OnEnable() => SoundManager.BeatDetection += SpawnTile;
    void OnDisable() => SoundManager.BeatDetection -= SpawnTile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void SpawnTile(float sum, float threshold)
    {
        // Convert threshold to columnIndex (0-3)
        int columnIndex = (int)(sum * 4f / threshold) % 4;
        // Spawn tile using id
        Instantiate(tilePrefab, initTilePosition + stepVector * xStep * columnIndex, Quaternion.identity);
    }
}
