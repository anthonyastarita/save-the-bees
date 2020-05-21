using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider bar;
    public float MaxTime = 20f;
    public float ActiveTime = 0f;
    public float percent;
    [SerializeField] private LevelManager levelManager;

    private void Awake()
    {
        levelManager.OnLevelStarted += OnLevelStarted;
    }

    public void Start()
	{
        bar = GetComponent<Slider>();
	}

    private void OnLevelStarted(int level)
    {
        MaxTime = 22f;
        ActiveTime = 0f;
    }

    public void Update()
    {
        ActiveTime += Time.deltaTime;
        percent = ActiveTime / MaxTime;
        bar.value = Mathf.Lerp(0, 1, percent);

    }


}
