using System.Collections;
using UnityEngine;

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

    private void Awake()
    {
        levelManager.OnLevelStarted += OnLevelStarted;
        levelManager.OnLevelEnded += OnLevelEnded;
    }


    private void OnLevelStarted(int level)
    {
        StartCoroutine(BranchGenerationUpdate());
    }

    private void OnLevelEnded(int level)
    {
        StopAllCoroutines();
    }

    private IEnumerator BranchGenerationUpdate()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetGenerationInterval);

            float nextBranchCoord = GetRandomXPosition;
            float sizeOfSpace = GetRandomSpacing;

            GameObject branchInstanceRight = Instantiate(branchPrefab);
            GameObject branchInstanceLeft= Instantiate(branchPrefab);
            branchInstanceRight.transform.position = new Vector3(nextBranchCoord + sizeOfSpace, 12, 0);
            branchInstanceLeft.transform.position = new Vector3(nextBranchCoord - sizeOfSpace, 12, 0);

            Vector3 newScale = branchInstanceLeft.transform.localScale;
            newScale.x *= -1;
            branchInstanceRight.transform.localScale = newScale;
        }
    }

    


}
