using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelCompletionDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private LevelManager levelManager;
    private Button nextLevelButton;

    public event Action OnClick;

    private const float DISPLAY_DELAY = 2.0f;

    private void Awake()
    {
        nextLevelButton = GetComponentInChildren<Button>(includeInactive: true);
        nextLevelButton.onClick.AddListener(OnNextLevelButtonClicked);

        levelManager.OnLevelEnded += OnLevelEnded;

        Display(false);
    }

    private void OnLevelEnded(int level)
    {
        StartCoroutine(DisplayDelay());
    }

    private IEnumerator DisplayDelay()
    {
        yield return new WaitForSeconds(DISPLAY_DELAY);
        Display();
    }

    private void Display(bool display = true)
    {
        nextLevelButton.gameObject.SetActive(display);
    }

    private void OnNextLevelButtonClicked()
    {
        OnClick?.Invoke();
        Display(false);

        //todo: add advertisement here
    }
}
