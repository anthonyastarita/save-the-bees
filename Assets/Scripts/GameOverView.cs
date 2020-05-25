using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject display;

    [SerializeField] private LevelManager levelManager;

    [SerializeField] private Button restartButton;

    public event Action Restart;

    private void Awake()
    {
        var gameOver = GetComponent<GameOver>();
        gameOver.OnGameOver += () => Display();

        levelManager.OnLevelStarted += GetRidOfDisplay;

        //restartButton = GetComponentInChildren<Button>(includeInactive: true);
        restartButton.onClick.AddListener(RestartLevel);

    }

    private void Display(bool show = true)
    {
        display.gameObject.SetActive(show);
    }


    private void GetRidOfDisplay(int level)
	{
        display.gameObject.SetActive(false);
    }



    private void RestartLevel()
	{
        Restart?.Invoke();
    }




}
