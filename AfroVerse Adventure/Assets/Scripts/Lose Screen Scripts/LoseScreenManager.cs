using UnityEngine;
using UnityEngine.UI;
public class LoseScreenManager : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _restartButton;

    private void Awake()
    {
        int highScore = PlayerPrefs.GetInt("Highscore");
        int score = PlayerPrefs.GetInt("Score");
        if (score > highScore)
            PlayerPrefs.SetInt("Highscore", score);
        _scoreText.text = $"You lose!\nScore: {PlayerPrefs.GetInt("Score")}";
        PlayerPrefs.SetInt("Score", 0);
    }
}
