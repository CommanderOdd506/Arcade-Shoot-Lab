using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public TMP_Text scoreText;

    private int score = 0;

    void OnEnable()
    {
        Enemy.OnEnemyHit += AddScore;
    }

    void OnDisable()
    {
        Enemy.OnEnemyHit -= AddScore;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateText();
    }

    void AddScore(int points)
    {
        score += points;
        UpdateText();
    }

    void UpdateText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}