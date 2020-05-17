using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class branchGenerator : MonoBehaviour
{

    public GameObject branch;
    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {

        coroutine = generateBranch(1.75f);
        StartCoroutine(coroutine);


    }


    private IEnumerator generateBranch(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);


            float nextBranchCoord = generateRandX();
            float sizeOfSpace = generateRandSpace();

            Vector3 rightBranchTip = new Vector3(0, 0, 0);
            Vector3 leftBranchTip = new Vector3(0, 0, 0);


            GameObject branchInstanceRight = Instantiate(branch);
            GameObject branchInstanceLeft= Instantiate(branch);
            branchInstanceRight.transform.position = new Vector3(nextBranchCoord + sizeOfSpace, 12, 0);
            branchInstanceLeft.transform.position = new Vector3(nextBranchCoord - sizeOfSpace, 12, 0);



            Vector3 newScale = branchInstanceLeft.transform.localScale;
            newScale.x *= -1;
            branchInstanceRight.transform.localScale = newScale;

            



        }
    }

    private float generateRandSpace()
    {

        return Random.Range(1.0f, 3.0f);

    }

    private float generateRandX()
	{

        return Random.Range(-6.0f, 6.0f);

	}



    // Update is called once per frame
    void Update()
    {


    }



}
