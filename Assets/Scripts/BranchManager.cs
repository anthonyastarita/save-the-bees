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
    private Camera cam;

    //so the color changer knows how long the leaf is going to be on the screen
    public float screenHeight { get; private set; } = 0;
    public float branchSpeed { get; private set; } = 0;


    private const float BASE_GENERATION_INTERVAL = 2.0f;
    private const float GENERATION_INTERVAL_GROWTH = 0.5f;
    private const float BASE_SPEED = -5.0f;

    //private float GetGenerationInterval => BASE_GENERATION_INTERVAL / (1 + ((levelManager.CurrentLevel - 1) * GENERATION_INTERVAL_GROWTH));
    private float GetGenerationInterval => BASE_GENERATION_INTERVAL;

    private float GetRandomSpacing => Random.Range(1.0f, 3.0f);
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
        cam = Camera.main;
        levelManager.OnLevelStarted += OnLevelStarted;
        levelManager.OnLevelEnded += OnLevelEnded;
    }


    private void OnLevelStarted(int level)
    {
        Color startColor = GetRandomColor;
        Color endColor = ContrastColor[startColor];

        InitDistanceTraveling();

        while (startColor == endColor)
        {
            endColor = GetRandomColor;
        }

        StartCoroutine(BranchGenerationUpdate(startColor,endColor));
    }



    private void InitDistanceTraveling()
	{

		var top = Camera.main.ScreenToWorldPoint(new Vector3(0, cam.pixelHeight, 0));
		var bot = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));

		screenHeight = top.y - bot.y;
        Debug.Log(screenHeight);
    }


    private void OnLevelEnded(int level)
    {
        StopAllCoroutines();
    }


    private IEnumerator BranchGenerationUpdate(Color startColor, Color endColor)
    {
        float speed = HowFast();
        branchSpeed = speed;

        while (true)
        {
            yield return new WaitForSeconds(GetGenerationInterval);

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

            leftBranch.velocity = new Vector2(0.0f, (speed));
            rightBranch.velocity = new Vector2(0.0f, (speed));
        }
    }


    private float HowFast()
	{

        int level = levelManager.CurrentLevel;
        float varience = 20.0f;

        //Debug.Log(BASE_SPEED);

        float baseSpeed = BASE_SPEED + ((level * 0.5f) * -1);

        int speedBonus = Random.Range(0, 3);

		//Debug.Log(speedBonus);


        //I wanted the levels to randomly be 10% faster or slower, to mix things up
		if (speedBonus == 0)
		{
            baseSpeed += (baseSpeed / varience);
		}
        else if (speedBonus == 1)
        {
            baseSpeed -= (baseSpeed / varience);
        }

        Debug.Log(baseSpeed);

        return baseSpeed;

	}


    


}
