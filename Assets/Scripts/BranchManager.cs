using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public static class ColorExtension
{
    public static Color purple = new Color(128, 0, 128);
    public static Color orange = new Color(255, 165, 0);
}

public class BranchManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject branchPrefab;
    [SerializeField] private Transform queen;

    public float BranchSpeed { get; private set; } = 0;

    private const float BASE_SPEED = 8.5f;
    private const float SPEED_GROWTH = 0.05f;
    private const float RANDOM_SPEED_BONUS = 1.20f;


    private const float BASE_GENERATION_INTERVAL = 2.0f;
    private const float GENERATION_INTERVAL_GROWTH = 0.5f;
    private float RANDOM_GENERATION_INTERVAL_FACTOR => 1 + Random.Range(0.0f, 0.5f * levelManager.CurrentLevel);
    private float GENERATION_INTERVAL => BASE_GENERATION_INTERVAL / (1 + ((levelManager.CurrentLevel - 1) * GENERATION_INTERVAL_GROWTH) / RANDOM_GENERATION_INTERVAL_FACTOR);


    private float GetRandomSpacing => Random.Range(1.5f, 3.5f);
    private float GetRandomXPosition => Random.Range(-6.0f, 6.0f);

    public event Action OnBranchPassedQueen;


    private readonly Dictionary<Color, Color> ContrastColor = new Dictionary<Color, Color>()
    {
        {Color.green, Color.red },
        {ColorExtension.purple, Color.yellow },
        {ColorExtension.orange, Color.cyan },
    };

    private Color GetRandomColor => ContrastColor.Keys.ElementAt(Random.Range(0, ContrastColor.Keys.Count));

    private void Awake()
    {
        levelManager.OnLevelStarted += OnLevelStarted;
        levelManager.OnLevelEnded += OnLevelEnded;

        levelManager.Restart += OnLevelRestarted;

    }


    private void OnLevelStarted(int level)
    {
        Color startColor = GetRandomColor;
        Color endColor = ContrastColor[startColor];

        while (startColor == endColor)
        {
            endColor = GetRandomColor;
        }

        StartCoroutine(BranchGenerationUpdate(startColor,endColor));
    }

    private void OnLevelEnded(int level)
    {
        StopAllCoroutines();
    }

    private void OnLevelRestarted()
    {
        StopAllCoroutines();
    }

    private IEnumerator BranchGenerationUpdate(Color startColor, Color endColor)
    {
        var speed = GetSpeed;
        BranchSpeed = speed;
        Debug.Log(GENERATION_INTERVAL);

        while (true)
        {
            // GENERATION_INTERVAL / RANDOM_GENERATION_INTERVAL_FACTOR
            yield return new WaitForSeconds(GetInterval());

            float nextBranchCoord = GetRandomXPosition;
            float sizeOfSpace = GetRandomSpacing;

            var rightBranch = Instantiate(branchPrefab).GetComponent<BranchFall>();
            var leftBranch = Instantiate(branchPrefab).GetComponent<BranchFall>();

            var leafColorLeft = leftBranch.GetComponent<LeafColorChanger>();
            leafColorLeft.Init(startColor, endColor);
            var leafColorRight = rightBranch.GetComponent<LeafColorChanger>();
            leafColorRight.Init(startColor, endColor);

            rightBranch.transform.position = new Vector3(nextBranchCoord + sizeOfSpace, 12, 0);
            leftBranch.transform.position = new Vector3(nextBranchCoord - sizeOfSpace, 12, 0);

            Vector3 newScale = leftBranch.transform.localScale;
            newScale.x *= -1;
            rightBranch.transform.localScale = newScale;

            rightBranch.Init(speed, queen.position.y);
            leftBranch.Init(speed, queen.position.y);

            rightBranch.OnBranchPassedQueen += () => OnBranchPassedQueen?.Invoke();
            leftBranch.OnBranchPassedQueen += () => OnBranchPassedQueen?.Invoke();

        }
    }



    private float GetInterval()
	{
		var top = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));
		var bot = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

		var screenHeight = top.y - bot.y;

		//time for the last branch to get to the middle
		var timeToMid = (screenHeight / 2) / BranchSpeed;

        var newTime = timeToMid * (Random.Range(0.60f, 1.20f));

        Debug.Log(newTime);
        //
        return newTime;

    }



    private float GetSpeed
	{
        get
        {
            float baseSpeed = BASE_SPEED + ((levelManager.CurrentLevel - 1) * SPEED_GROWTH);

            int randIndex = Random.Range(0, 3);

            baseSpeed = randIndex == 0 ? baseSpeed + RANDOM_SPEED_BONUS : baseSpeed - RANDOM_SPEED_BONUS;

            Debug.Log(baseSpeed);

            return baseSpeed;
        }

        

	}


    


}
