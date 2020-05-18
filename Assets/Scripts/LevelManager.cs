using System;
using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    private int currentLevel = 0;
    private const float LEVEL_DURATION = 20.0f;

    public event Action<int> OnLevelStarted;
    public event Action<int> OnLevelEnded;

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        currentLevel++;
        Debug.Log($"Level {currentLevel} has started.");
        OnLevelStarted?.Invoke(currentLevel);
        StartCoroutine(EndLevel());
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(LEVEL_DURATION);
        Debug.Log($"Level {currentLevel} has ended.");
        OnLevelEnded?.Invoke(currentLevel);
    }
}
