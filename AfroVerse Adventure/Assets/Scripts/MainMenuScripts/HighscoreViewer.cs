using UnityEngine;
using UnityEngine.UI;

public class HighscoreViewer : MonoBehaviour
{
    [SerializeField] private Text _highscoreText;
    private void Awake()
    {
        _highscoreText.text = $"Highscore: {PlayerPrefs.GetInt("Highscore").ToString()}";
    }
}
