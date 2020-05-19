using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ColorExtension
{
    public static Color purple = new Color(128, 0, 128);
    public static Color orange = new Color(255, 165, 0);
}

public class BranchGenerator : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject branchPrefab;

    private const float BASE_GENERATION_INTERVAL = 2.0f;
    private const float GENERATION_INTERVAL_GROWTH = 0.5f;

    private float GetGenerationInterval => BASE_GENERATION_INTERVAL / (1 + ((levelManager.CurrentLevel - 1) * GENERATION_INTERVAL_GROWTH));

    private float GetRandomSpacing => Random.Range(1.0f, 3.0f);
    private float GetRandomXPosition => Random.Range(-6.0f, 6.0f);



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
        while (true)
        {
            yield return new WaitForSeconds(GetGenerationInterval);

            float nextBranchCoord = GetRandomXPosition;
            float sizeOfSpace = GetRandomSpacing;

            GameObject branchInstanceRight = Instantiate(branchPrefab);
            GameObject branchInstanceLeft= Instantiate(branchPrefab);

            var leafColorLeft = branchInstanceLeft.GetComponent<LeafColorChanger>();
            leafColorLeft.Init(startColor, endColor);
            var leafColorRight = branchInstanceRight.GetComponent<LeafColorChanger>();
            leafColorRight.Init(startColor, endColor);

            branchInstanceRight.transform.position = new Vector3(nextBranchCoord + sizeOfSpace, 12, 0);
            branchInstanceLeft.transform.position = new Vector3(nextBranchCoord - sizeOfSpace, 12, 0);

            Vector3 newScale = branchInstanceLeft.transform.localScale;
            newScale.x *= -1;
            branchInstanceRight.transform.localScale = newScale;
        }
    }

    


}
