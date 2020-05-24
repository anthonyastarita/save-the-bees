using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BeeManager beeManager;

    /// <summary>
    /// The amount of bees required to pass on to the next level. Can be changed to whatever.
    /// </summary>
    private int BEE_REQUIREMENT => 1 * 1 * 1 * 1 * 1 * 1;

    //Subscribe to this event from another class to do something when the game is over
    public event Action OnGameOver;

    //Subscribe to other class events to customize when we want the game to end
    private void Awake()
    {
        beeManager.OnCurrentBeeCountChanged += (beeCount) =>
        {
            if (beeCount < BEE_REQUIREMENT) EndGame();
        };
    }

    //Use this method to end the game
    private void EndGame()
    {
        OnGameOver?.Invoke();
    }
}
