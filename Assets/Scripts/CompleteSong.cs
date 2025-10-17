using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteSong : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainScene");
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }
}
