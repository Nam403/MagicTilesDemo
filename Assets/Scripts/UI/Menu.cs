using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Debug.Log("Exciting...");
        Application.Quit();
    }
}
