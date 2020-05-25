using System;
using System.Collections;
using UnityEngine.Events;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelCompletionDisplay levelCompletionDisplay;

    [SerializeField] private GameOverView gameOver;
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private GameObject levelOverDisplay;


    [SerializeField] private GameObject arrows;


    //public int CurrentLevel { get; private set; } = 0;


	public int CurrentLevel
	{
		get => PlayerPrefs.GetInt("Level", 0);
		set
		{
			PlayerPrefs.SetInt("Level", value);
		}
	}

	private const float LEVEL_DURATION = 20.0f;

    public event Action<int> OnLevelStarted;
    public event Action<int> OnLevelEnded;
    public event Action Restart;

    private void Awake()
    {
        levelCompletionDisplay.OnClick += StartLevel;
        gameOver.Restart += RestartLevel;
    }

    private void Start()
    {
        StartCoroutine(ActuallyStart());
    }


    private IEnumerator ActuallyStart()
	{
        yield return new WaitForSeconds(2.5f);

        arrows.SetActive(false);
        StartLevel();
	}


    private void StartLevel()
    {
        CurrentLevel++;
        Debug.Log($"Level {CurrentLevel} has started.");
        OnLevelStarted?.Invoke(CurrentLevel);
        StartCoroutine(EndLevel());
    }


    //
    private IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(LEVEL_DURATION);

        Debug.Log($"Level {CurrentLevel} has ended.");
        OnLevelEnded?.Invoke(CurrentLevel);
    }

    private void DestoryAllBranches()
	{
        GameObject[] branches = GameObject.FindGameObjectsWithTag("branch");
        foreach (GameObject branch in branches)
		{
            branch.SetActive(false);
        }
    }

    private void OnApplicationQuit()
    {
        CurrentLevel--;
    }

    private void RestartLevel()
	{
        //OnLevelStarted.RemoveAllListeners();
        //OnLevelEnded?.Invoke(CurrentLevel);

        Debug.Log("RESTARtING LEVEL");
        DestoryAllBranches();
        gameOverDisplay.SetActive(false);
        levelOverDisplay.SetActive(false);
        StopAllCoroutines();
        Restart?.Invoke();


        //OnLevelStarted?.Invoke(CurrentLevel);
        CurrentLevel--;



        //OnLevelEnded.RemoveAllListeners();
        StartLevel();

        Debug.Log($"Level {CurrentLevel} has started.");
        //OnLevelStarted?.Invoke(CurrentLevel);
        //StartCoroutine(EndLevel());

    }


}
