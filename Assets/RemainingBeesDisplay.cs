using UnityEngine;
using UnityEngine.UI;

public class RemainingBeesDisplay : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private BeeManager beeManager;

    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        beeManager.OnCurrentBeeCountChanged += UpdateDisplay;
    }

    private void Start()
    {
        UpdateDisplay(beeManager.CurrentBeeCount);
    }

    private void UpdateDisplay(int beeCount)
    {
        text.text = $"Bees:\n{beeCount}";
    }
}
