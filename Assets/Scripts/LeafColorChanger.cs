using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafColorChanger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<SpriteRenderer> leafSprites;

    private const float LERP_TIME = 6.0f;

    public void Init(Color startColor, Color endColor)
    {
        StartCoroutine(ColorLerp(startColor, endColor));
    }

    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {

        float startTime = Time.time;
        float percentageComplete = 0;

        while (percentageComplete < 1)
        {
            float elapsedTime = Time.time - startTime;
            percentageComplete = elapsedTime / (LERP_TIME);

            leafSprites.ForEach((leaf) =>
            {
                leaf.color = Color.Lerp(startColor, endColor, percentageComplete);
            });

            yield return null; 
        }
    }
}
