using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteSong : MonoBehaviour
{
    public void Replay()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
