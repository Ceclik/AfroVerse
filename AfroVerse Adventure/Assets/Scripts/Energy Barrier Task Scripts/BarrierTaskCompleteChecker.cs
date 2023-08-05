using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarrierTaskCompleteChecker : MonoBehaviour
{
    [SerializeField] private List<Image> _sources;
    [SerializeField] private List<Image> _platePlaces;

    [SerializeField] private GameplaySceneLoader _gamePlaySceneLoader;
    [SerializeField] private LoseSceneLoader _loseSceneLoader;

    [SerializeField] private float _taskTime;

    private float _runningTime;

    private void OnEnable()
    {
        foreach(var platePlace in _platePlaces)
            platePlace.GetComponent<IsPlatePlacedChecker>().OnPlatePlaced += AllPlatesPlaced;
    }

    private void OnDisable()
    {
        foreach (var platePlace in _platePlaces)
            platePlace.GetComponent<IsPlatePlacedChecker>().OnPlatePlaced -= AllPlatesPlaced;
    }

    private void AllPlatesPlaced()
    {
        foreach (var platePlace in _platePlaces)
            if (!platePlace.GetComponent<IsPlatePlacedChecker>().IsPlatePlaced)
                return;
        if (CorrectPlaceCheck())
            SceneManager.LoadScene(1);
        else
            _loseSceneLoader.LoadLoseScene();
    }

    private bool CorrectPlaceCheck()
    {
        for (int i = 0; i < 3; i++)
        {
            Image[] platePlaceChildren = new Image[_platePlaces[i].GetComponentsInChildren<Image>().Length];
            platePlaceChildren = _platePlaces[i].GetComponentsInChildren<Image>();
            if (platePlaceChildren[1].sprite != _sources[i].GetComponent<Image>().sprite)
                return false;
        }
        return true;
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;
        if (_runningTime > _taskTime)
            _loseSceneLoader.LoadLoseScene();
    }
}
