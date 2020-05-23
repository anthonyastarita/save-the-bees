using System;
using UnityEngine;

public class BeeManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform queen;
    [SerializeField] private Transform beePrefab;
    [SerializeField] private LevelManager levelManager;

    private const int INITIAL_BEE_COUNT = 9;
    private int BEES_PER_LEVEL => 1;

    private int currentBeeCount = 0;
    public int CurrentBeeCount
    {
        get => currentBeeCount;
        set
        {
            currentBeeCount = value;
            OnCurrentBeeCountChanged?.Invoke(currentBeeCount);
        }
    }

    public event Action<int> OnCurrentBeeCountChanged;

    private void Awake()
    {
        InitSwarm();
        levelManager.OnLevelStarted += OnLevelStarted;
    }

    private void OnLevelStarted(int level)
    {
        for(int i = 0; i < (BEES_PER_LEVEL); i++)
        {
            SpawnBee();
        }

        Debug.Log($"{BEES_PER_LEVEL} bees spawned");
    }

    private void InitSwarm()
    {
        for(int i = 0; i < INITIAL_BEE_COUNT; i++)
        {
            SpawnBee();
        }

        Debug.Log($"{INITIAL_BEE_COUNT} bees spawned");

    }

    private void SpawnBee()
    {
        Transform bee = Instantiate(beePrefab);
        bee.position = queen.position;


        FollowQueen followScript = bee.GetComponent<FollowQueen>();
        followScript.Init(queen);

        CurrentBeeCount++;
        bee.GetComponent<DisableOffScreen>().OnDisable += () => CurrentBeeCount--;
    }
}
