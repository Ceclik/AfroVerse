using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(SwipeDetector))]
[RequireComponent(typeof(ScreenAspectCounter))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _durationOfMoving;

    private ScreenAspectCounter _screenAspectCounter;
    private const float _lineCoordCoeficient = 0.32f;
    private float _newX;

    private int _currentRoad;
    private Vector3 _targetPosition;

    private void Start()
    {
        SwipeDetector.SwipeEvent += OnSwipe;

        _screenAspectCounter = GetComponent<ScreenAspectCounter>();
        _newX = _lineCoordCoeficient * _screenAspectCounter.ScreenWidth;
        _currentRoad = 2;
        if (_durationOfMoving == 0)
            _durationOfMoving = 0.1f;
    }

    private void OnDestroy()
    {
        SwipeDetector.SwipeEvent -= OnSwipe;
    }

    private void OnSwipe(Vector2 direction)
    {
        if (direction == Vector2.right)
            MoveRight();
        else if(direction == Vector2.left)
            MoveLeft();
    }

    public void MoveRight()
    {
        if (_currentRoad < 3)
        {
            GetComponent<AudioSource>().Play();
            if (_currentRoad == 1)
                MoveToSecondRoad();
            else if (_currentRoad == 2)
                MoveToThirdRoad();
            _currentRoad++;
        }
    }
    public void MoveLeft()
    {
        if (_currentRoad > 1) 
        {
            GetComponent<AudioSource>().Play();
            if (_currentRoad == 3)
                MoveToSecondRoad();
            else if( _currentRoad == 2)
                MoveToFirstRoad();
            _currentRoad--;
        }
    }

    private void MoveToSecondRoad()
    {
        _targetPosition = new Vector3(0, transform.position.y, 0);
        transform.DOMove(_targetPosition, _durationOfMoving);
    }
    private void MoveToThirdRoad()
    {
        _targetPosition = new Vector3(_newX, transform.position.y, 0);
        transform.DOMove(_targetPosition, _durationOfMoving);
    }
    private void MoveToFirstRoad()
    {
        _targetPosition = new Vector3(-_newX, transform.position.y, 0);
        transform.DOMove(_targetPosition, _durationOfMoving);
    }
}
    