using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController Instance;
    public ScoreVariable scoreVariable;
    
    [SerializeField] private TMP_Text scoreTMPText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ResetScore();
        StartFillScore();
    }

    private void StartFillScore()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreTMPText.text = "Score : " + scoreVariable.Score;
    }

    public void AddScore()
    {
        if (scoreVariable.Score <= 100)
        {
            scoreVariable.Score += 10;
        }

        if (scoreVariable.Score >= 100)
        {
            GameController.Instance.GameCompleted();
        }
        
        UpdateScoreText();
    }

    public void ResetScore()
    {
        scoreVariable.Score = 0;
    }
}
