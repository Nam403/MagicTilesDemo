using TMPro;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    static int Score;
    static int Target;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] Image processBar;
    [SerializeField] GameObject star;
    [SerializeField] TextMeshProUGUI timingTapText;

    [SerializeField] int goodTapBonus = 1;
    [SerializeField] int perfectTapBonus = 2;
    [SerializeField] int point = 1;
    [SerializeField] int bonus = 10;
    int combo;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.Log("More than one ScoreManager in scene!");
            return;
        }
        Instance = this;
    }

    void OnEnable()
    {
        SoundManager.SongEnd += UpdateHighestScore;
        Border.GameOver += UpdateHighestScore;
        TimingBar.GoodTap += HandleGoodTap;
        TimingBar.MissTap += HandleMissTap;
        TimingBar.PerfectTap += HandlePerfectTap;
    }
    void OnDisable()
    {
        SoundManager.SongEnd -= UpdateHighestScore;
        Border.GameOver -= UpdateHighestScore;
        TimingBar.GoodTap -= HandleGoodTap;
        TimingBar.MissTap -= HandleMissTap;
        TimingBar.PerfectTap -= HandlePerfectTap;
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        combo = 0;
        Target = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(combo >= bonus) // Get bonus
        {
            // Reset combo
            Score += bonus;
            combo -= bonus;
        }

        scoreText.text = Score.ToString();
        processBar.fillAmount = (Score * 1f) / (Target * 1f);

        if(Score > Target && !star.activeSelf)
        {
            star.SetActive(true);
        }
    }

    public void UpdateHighestScore()
    {
        if(Score > Target)
        {
            PlayerPrefs.SetInt("HighScore", Score);
            PlayerPrefs.Save();
        }
    }

    void HandleGoodTap()
    {
        Score += point;
        timingTapText.text = "Good";
        combo += goodTapBonus;
    }

    void HandleMissTap()
    {
        Score += point;
        timingTapText.text = "Miss";
        combo = 0; // Reset combo
    }

    void HandlePerfectTap()
    {
        Score += point * 2;
        timingTapText.text = "Perfect";
        combo += perfectTapBonus;
    }
}
