using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelCompletionDisplay levelCompletionDisplay;

    public int CurrentLevel { get; private set; } = 100;

    private const float LEVEL_DURATION = 20.0f;

    public event Action<int> OnLevelStarted;
    public event Action<int> OnLevelEnded;

    private void Awake()
    {
        levelCompletionDisplay.OnClick += StartLevel;
    }

    private void Start()
    {
        StartLevel();
    }

    private void StartLevel()
    {
        CurrentLevel++;
        Debug.Log($"Level {CurrentLevel} has started.");
        OnLevelStarted?.Invoke(CurrentLevel);
        StartCoroutine(EndLevel());
    }

    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(LEVEL_DURATION);
        Debug.Log($"Level {CurrentLevel} has ended.");
        OnLevelEnded?.Invoke(CurrentLevel);
    }
}
