using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeDown : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;


    //public event Action<int> OnScore;


    public void Start()
	{
        scoreManager = GameObject.FindWithTag("ScoreManager").GetComponent<ScoreManager>();
    }


    private void OnBecameInvisible()
    {
        if (transform.position.y < Camera.main.ScreenToWorldPoint(Vector3.zero).y)
            scoreManager.BeesAlive--;
    }
}
