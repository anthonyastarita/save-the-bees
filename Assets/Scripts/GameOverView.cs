using UnityEngine;

public class GameOverView : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject display;

    private void Awake()
    {
        var gameOver = GetComponent<GameOver>();
        gameOver.OnGameOver += () => Display();
    }

    private void Display(bool show = true)
    {
        display.gameObject.SetActive(show);
    }
}
