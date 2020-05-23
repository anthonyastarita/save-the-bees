using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

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

    public float branchSpeed { get; private set; } = 0;

    private const float BASE_SPEED = 5.0f;
    private const float SPEED_GROWTH = 0.5f;
    private const float RANDOM_SPEED_BONUS = 1.20f;


    private const float BASE_GENERATION_INTERVAL = 2.0f;
    private const float GENERATION_INTERVAL_GROWTH = 0.5f;
    private float RANDOM_GENERATION_INTERVAL_FACTOR => 1 + Random.Range(0.0f, 0.5f * levelManager.CurrentLevel);
    private float GENERATION_INTERVAL => BASE_GENERATION_INTERVAL / (1 + ((levelManager.CurrentLevel - 1) * GENERATION_INTERVAL_GROWTH) / RANDOM_GENERATION_INTERVAL_FACTOR);


    private float GetRandomSpacing => Random.Range(1.5f, 3.5f);
    private float GetRandomXPosition => Random.Range(-6.0f, 6.0f);

    private Rigidbody2D leftBranch;
    private Rigidbody2D rightBranch;


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


    private IEnumerator BranchGenerationUpdate(Color startColor, Color endColor)
    {
        var speed = GetSpeed;
        Debug.Log(GENERATION_INTERVAL);

        while (true)
        {
            // / RANDOM_GENERATION_INTERVAL_FACTOR
            yield return new WaitForSeconds(GENERATION_INTERVAL / RANDOM_GENERATION_INTERVAL_FACTOR);

            float nextBranchCoord = GetRandomXPosition;
            float sizeOfSpace = GetRandomSpacing;

            GameObject branchInstanceRight = Instantiate(branchPrefab);
            GameObject branchInstanceLeft = Instantiate(branchPrefab);

            var leafColorLeft = branchInstanceLeft.GetComponent<LeafColorChanger>();
            leafColorLeft.Init(startColor, endColor);
            var leafColorRight = branchInstanceRight.GetComponent<LeafColorChanger>();
            leafColorRight.Init(startColor, endColor);

            branchInstanceRight.transform.position = new Vector3(nextBranchCoord + sizeOfSpace, 12, 0);
            branchInstanceLeft.transform.position = new Vector3(nextBranchCoord - sizeOfSpace, 12, 0);

            Vector3 newScale = branchInstanceLeft.transform.localScale;
            newScale.x *= -1;
            branchInstanceRight.transform.localScale = newScale;

            leftBranch = branchInstanceLeft.AddComponent<Rigidbody2D>() as Rigidbody2D;
            rightBranch = branchInstanceRight.AddComponent<Rigidbody2D>() as Rigidbody2D;

			leftBranch.bodyType = RigidbodyType2D.Kinematic;
			rightBranch.bodyType = RigidbodyType2D.Kinematic;

            leftBranch.velocity = new Vector2(0.0f, speed * -1);
            rightBranch.velocity = new Vector2(0.0f, speed * -1);
        }
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
