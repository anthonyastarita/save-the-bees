using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class updateScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;

    void onEnable()
	{
        eventManager.onPassBranch += UpdateScore;
	}


    // Start is called before the first frame update
    void Start()
    {
        //score.text = "Yoyo";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScore()
	{
        //score.text = "Yoyo";
	}


}
