using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafColorChanger : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private List<SpriteRenderer> leafSprites;
    [SerializeField] private BranchManager branchManager;

    private float lerpTime = 4.0f;


 //   void Start()
	//{
 //       branchManager = GameObject.FindWithTag("BranchManager").GetComponent<BranchManager>();
 //   }

    public void Init(Color startColor, Color endColor)
    {
        branchManager = GameObject.FindWithTag("BranchManager").GetComponent<BranchManager>();
        InitLerpTime();
        StartCoroutine(ColorLerp(startColor, endColor));
    }

    private void InitLerpTime()
	{
        //lerpTime = distance/rate?
        float preLerpTime = branchManager.screenHeight / Mathf.Abs(branchManager.branchSpeed);

        lerpTime = preLerpTime;

	}

    private IEnumerator ColorLerp(Color startColor, Color endColor)
    {

        float startTime = Time.time;
        float percentageComplete = 0;

        while (percentageComplete < 1)
        {
            float elapsedTime = Time.time - startTime;
            percentageComplete = elapsedTime / (lerpTime);

            leafSprites.ForEach((leaf) =>
            {
                leaf.color = Color.Lerp(startColor, endColor, percentageComplete);
            });

            yield return null; 
        }
    }
}
