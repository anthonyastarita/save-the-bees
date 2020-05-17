using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorOverTime : MonoBehaviour
{

    SpriteRenderer leafSprite;
    public float lerpTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        leafSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(ColorLerp());
    }




    IEnumerator ColorLerp()
    {

        float startTime = Time.time;
        float percentageComplete = 0;

        while (percentageComplete < 1)
        {
            float elapsedTime = Time.time - startTime;
            percentageComplete = elapsedTime / (lerpTime);
            leafSprite.color = Color.Lerp(Color.green, Color.red, percentageComplete);
            yield return null;
        }
    }

}
