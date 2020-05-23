using UnityEngine;
using UnityEngine.UI;

public class CurrentScoreDisplay : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;

    private void Awake()
    {
        var text = GetComponent<Text>();
        scoreManager.OnCurrentScoreChanged += (score) =>
        {
            text.text = score.ToString();
        };
    }
}
