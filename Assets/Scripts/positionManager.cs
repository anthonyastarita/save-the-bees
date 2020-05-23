using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionManager : MonoBehaviour
{

    [SerializeField] private LevelManager levelManager;

    public GameObject Queen;
    public GameObject Swarm;

    private Vector3 queenPos;

    void Start()
	{
        queenPos = Queen.transform.position;

        float[] layers = { 0.5f, 1.0f, 1.5f, 2.0f, 2.5f};

        int[] ringSize = { 7, 13, 19, 25, 33 };
        int[] beesSpawning;


		for (int i = 0; i < 5; i++)
		{
			InitSwarm(layers[i], ringSize[i]);
		}



		//InitSwarm(layers[i], ringSize[i]);

	}


    void InitSwarm(float dist, int numRing)
    {

        Vector3 targetPos = Vector3.zero;

   
        for (int i = 0; i < numRing; i++)
        {

            GameObject instance = Instantiate(Swarm);

            float angle = i * (2 * 3.14159f / numRing);

            float x = Mathf.Cos(angle) * dist;

            float y = Mathf.Sin(angle) * dist;

            targetPos = new Vector3(queenPos.x + x, queenPos.y + y, 0);

            instance.transform.position = targetPos;

            FollowQueen followScript = instance.GetComponent<FollowQueen>();
            followScript.Init(Queen.transform);

            //instance.transform.SetParent(Queen.transform);

        }

    }



}
