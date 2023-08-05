using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ScreenAspectCounter))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _encreasingSpeedDelta;

    private int _roadNumber;
    private Vector3 _targetPosition;

    private ScreenAspectCounter _screenAspectCounter;
    private const float _lineCoordCoeficient = 0.32f;
    private float _newX;

    private void Start()
    {
        _screenAspectCounter = GetComponent<ScreenAspectCounter>();
        _newX = _lineCoordCoeficient * _screenAspectCounter.ScreenWidth;

        if (TryGetComponent<BlackHole>(out BlackHole bh))
        {
            do
                _roadNumber = Random.Range(1, 4);
            while (_roadNumber == 2);
        }
        else _roadNumber = Random.Range(1, 4);

        switch (_roadNumber)
        {
            case 1: 
                MoveToFirstRoad(); 
                break;
            case 2:
                MoveToSecondRoad();
                break;
            case 3:
                MoveToThirdRoad();
                break;
        }
    }
    private void Update()
    {
        _targetPosition = new Vector3(transform.position.x, transform.position.y - 12, 0);
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
    private void MoveToSecondRoad()
    {
        transform.position = new Vector3(0, transform.position.y, 0);
    }
    private void MoveToThirdRoad()
    {
        transform.position = new Vector3(_newX, transform.position.y, 0);
        if(transform.childCount > 0)
            transform.rotation = new Quaternion(0, 0, 180, 0);
    }
    private void MoveToFirstRoad()
    {
        transform.position = new Vector3(-_newX, transform.position.y, 0);
    }

    private IEnumerator EnemyAccelerator()
    {
        yield return new WaitForSeconds(_encreasingSpeedDelta);
        _speed += _encreasingSpeedDelta;
        StartCoroutine(EnemyAccelerator());
    }
}
