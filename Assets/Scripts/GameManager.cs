using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static bool GameIsOver;
    [SerializeField] GameObject completeSongUI;
    [SerializeField] GameObject gameOverUI;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one GameManager in scene!");
            return;
        }
        Instance = this;
    }

    void OnEnable()
    {
        SoundManager.SongEnd += CompleteSong;
        Border.GameOver += EndGame;
    } 
    void OnDisable()
    {
        SoundManager.SongEnd -= CompleteSong;
        Border.GameOver -= EndGame;
    } 

    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameIsOver)
        {
            return;
        }
    }

    public void CompleteSong()
    {
        GameIsOver = false;
        completeSongUI.SetActive(true);
    }

    public void EndGame()
    {
        GameIsOver = true;
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
}
