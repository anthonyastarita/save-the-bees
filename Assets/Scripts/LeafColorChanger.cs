using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafColorChanger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<SpriteRenderer> leafSprites;

    public void Init(Color startColor, Color endColor)
    {
        StartCoroutine(ColorLerp(startColor, endColor));
    }

    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {
        float startTime = Time.time;
        float percentageComplete = 0;

        var top = Camera.main.ScreenToWorldPoint(new Vector3(0, Camera.main.pixelHeight, 0));
        var bot = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        var screenHeight = top.y - bot.y;

        while (percentageComplete < 1)
        {
            float elapsedTime = Time.time - startTime;

            var distanceTraveled = top.y - transform.position.y;
            percentageComplete = distanceTraveled / screenHeight;

            leafSprites.ForEach((leaf) =>
            {
                leaf.color = Color.Lerp(startColor, endColor, percentageComplete);
            });

            yield return null; 
        }
    }
}
