using UnityEngine;

public class TaskCompleteChecker : MonoBehaviour
{
    private LoseSceneLoader _loseSceneLoader;
    private GameplaySceneLoader _gameplaySceneLoader;

    [SerializeField] private float _completeTime;

    private GameObject[] _blackHoleVariants;
    private Color _originalBlackHoleColor;
    private float _runningTime;

    private void Start()
    {
        _gameplaySceneLoader = GetComponent<GameplaySceneLoader>();
        _loseSceneLoader = GetComponent<LoseSceneLoader>();
        _originalBlackHoleColor = new Color(PlayerPrefs.GetFloat("BlackHoleRed"), PlayerPrefs.GetFloat("BlackHoleGreen"), PlayerPrefs.GetFloat("BlackHoleBlue"), 1);
        _blackHoleVariants = new GameObject[4];
        _blackHoleVariants = GameObject.FindGameObjectsWithTag("BlackHole");
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;
        if (_runningTime > _completeTime)
            _loseSceneLoader.LoadLoseScene();
        foreach (var blackHoleVariant in _blackHoleVariants)
            if(blackHoleVariant.GetComponent<ClickHandler>().IsClicked)
                if (blackHoleVariant.GetComponent<SpriteRenderer>().color == _originalBlackHoleColor)
                    _gameplaySceneLoader.LoadGameplayScene();
                else
                    _loseSceneLoader.LoadLoseScene();
    }
}
