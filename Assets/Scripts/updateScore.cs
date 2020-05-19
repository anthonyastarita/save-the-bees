using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class updateScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    [SerializeField] private LevelManager levelManager;

    public int sum = 0;

    private void Awake()
    {
        score = GetComponent<TextMeshProUGUI>();
        levelManager.OnLevelStarted += OnLevelStarted;
        levelManager.OnLevelEnded += OnLevelEnded;
    }

    private void OnLevelStarted(int level)
    {
        StartCoroutine(UpdateScore(level));
    }

    private void OnLevelEnded(int level)
    {
        StopAllCoroutines();
    }

    private IEnumerator UpdateScore(int level)
    {

        yield return new WaitForSeconds(3.5f);

        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            //points are the number of bees alive, times the level number
            sum += level;
            score.SetText(sum.ToString());

        }
    }


}
