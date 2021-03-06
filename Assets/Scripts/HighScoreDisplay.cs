﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreDisplay : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    private void Awake()
    {
        var text = GetComponent<Text>();
        text.text = scoreManager.HighScore.ToString();
        scoreManager.OnHighScoreChanged += (score) =>
        {
            text.text = score.ToString();
        };

    }
}
