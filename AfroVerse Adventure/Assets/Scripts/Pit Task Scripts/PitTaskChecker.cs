using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TaskGenerator))]
public class PitTaskChecker : MonoBehaviour
{
    [SerializeField] private Button _firstDoor;
    [SerializeField] private Button _secondDoorDoor;
    [SerializeField] private Button _thirdDoor;

    [SerializeField] private GameplaySceneLoader _gameplaySceneLoader;
    [SerializeField] private LoseSceneLoader _loseSceneLoader;

    [SerializeField] private float _timeToSolve;

    private TaskGenerator _task;
    private int _numberOfCorrectDoor;
    private float _runningTime;

    private void Start()
    {
        _task = GetComponent<TaskGenerator>();
        _numberOfCorrectDoor = _task.NumberOfCorrectDoor;
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;
        if (_runningTime > _timeToSolve)
            _loseSceneLoader.LoadLoseScene();
    }

    public void OnFirstDoorClick()
    {
        if ( _numberOfCorrectDoor == 1)
            _gameplaySceneLoader.LoadGameplayScene();
        else 
            _loseSceneLoader.LoadLoseScene();
    }

    public void OnSecondDoorClick()
    {
        if (_numberOfCorrectDoor == 2)
            _gameplaySceneLoader.LoadGameplayScene();
        else
            _loseSceneLoader.LoadLoseScene();
    }

    public void OnThirdDoorClick() 
    {
        if (_numberOfCorrectDoor == 3)
            _gameplaySceneLoader.LoadGameplayScene();
        else
            _loseSceneLoader.LoadLoseScene();
    }
}
