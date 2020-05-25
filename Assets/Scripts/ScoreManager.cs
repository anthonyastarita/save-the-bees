using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private BranchManager branchManager;
    [SerializeField] private BeeManager beeManager;

    private int currentScore = 0;
    private int CurrentScore
    {
        get => currentScore;
        set
        {
            currentScore = value;
            OnCurrentScoreChanged?.Invoke(currentScore);
            if (CurrentScore > HighScore) HighScore = CurrentScore;
        }
    }

    public int HighScore
    {
        get => PlayerPrefs.GetInt(HIGHSCORE_KEY, 0);
        private set
        {
            PlayerPrefs.SetInt(HIGHSCORE_KEY, value);
            OnHighScoreChanged?.Invoke(value);
        }
    }

    private const string HIGHSCORE_KEY = "HIGHSCORE_KEY";

    public event Action<int> OnCurrentScoreChanged;
    public event Action<int> OnHighScoreChanged;

    private void Awake()
    {
        levelManager.OnLevelEnded += OnLevelEnded;
        branchManager.OnBranchPassedQueen += OnBranchPassedQueen;
    }

    private void OnLevelEnded(int level)
    {
        CurrentScore += 100;
    }

    private void OnBranchPassedQueen()
    {
        CurrentScore += (beeManager.CurrentBeeCount * levelManager.CurrentLevel);
    }

    

    
}
