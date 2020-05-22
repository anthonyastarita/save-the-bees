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
        scoreManager.BeesAlive--;
    }
}
