using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private LevelManager levelManager;
    [SerializeField] public bool isRight = false;

    private void Awake()
    {
        levelText = GetComponent<TextMeshProUGUI>();
        levelManager.OnLevelStarted += OnLevelStarted;
        //levelManager.OnLevelEnded += OnLevelEnded;
    }

    private void OnLevelStarted(int level)
    {
        if (isRight)
        {
            level++;
        }
        levelText.SetText(level.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
