using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Player))]
public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private int _score;
    private Player _player;

    private void Start()
    {
        _score = PlayerPrefs.GetInt("Score");
        _player = GetComponent<Player>();
        StartCoroutine(scoreCounter());
    }

    private IEnumerator scoreCounter()
    {
        yield return new WaitForSeconds(0.5f);
        _score += 2;
        _scoreText.text = $"Score: {_score}";
        PlayerPrefs.SetInt("Score", _score);
        if(_player.IsAlive)
            StartCoroutine(scoreCounter());
    }
}
