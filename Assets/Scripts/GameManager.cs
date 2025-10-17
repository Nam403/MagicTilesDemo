using System.Collections;
using System.Collections.Generic;
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

    // Start is called before the first frame update
    void Start()
    {
        GameIsOver = false;
        ScoreManager.Instance.SetUp(120);
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
        Time.timeScale = 0f;
        completeSongUI.SetActive(true);
    }

    public void EndGame()
    {
        GameIsOver = true;
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
    }
}
