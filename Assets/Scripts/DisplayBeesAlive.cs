using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayBeesAlive : MonoBehaviour
{

    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] TextMeshProUGUI beeCount;


    void Awake()
	{
        beeCount = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        //beeCount.SetText(scoreManager.BeesAlive.ToString());
    }
}
