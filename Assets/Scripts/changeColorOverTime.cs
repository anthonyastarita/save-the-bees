using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Behaviour moved to LeafColorChanger.cs")]
public class changeColorOverTime : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<SpriteRenderer> spritesToChange;

    private const float LERP_TIME = 6.0f;

    void Start()
    {
        StartCoroutine(ColorLerp());
    }

    IEnumerator ColorLerp()
    {

        float startTime = Time.time;
        float percentageComplete = 0;

        while (percentageComplete < 1)
        {
            float elapsedTime = Time.time - startTime;
            percentageComplete = elapsedTime / (LERP_TIME);
            //leafSprite.color = Color.Lerp(Color.green, Color.red, percentageComplete);
            yield return null;
        }
    }

}
