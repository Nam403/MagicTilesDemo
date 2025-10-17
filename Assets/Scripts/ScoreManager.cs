using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    static int Score;
    static int Target;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Image processBar;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one ScoreManager in scene!");
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
    }

    public void SetUp(int target)
    {
        Target = target;
    }

    public void UpdateScore(int amount)
    {
        Score += amount;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = Score.ToString();
        processBar.fillAmount = (Score * 1f) / (Target * 1f);

        if(Score == Target)
        {
            GameManager.Instance.CompleteSong();
        }
    }
}
