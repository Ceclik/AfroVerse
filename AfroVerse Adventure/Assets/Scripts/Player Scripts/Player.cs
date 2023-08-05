using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ScreenAspectCounter))]
public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _onBlackHoleCollision;
    [SerializeField] private UnityEvent _onPitCollision;
    [SerializeField] private UnityEvent _onEnergyBarrierCollision;

    [SerializeField] private float _durationOfMoveDown;

    private ScreenAspectCounter _screenaspectCounter;
    private const float _scaleCooficeent = 0.2f;
    private float _scaleValue;

    private Vector3 _currentPosition;
    private bool _isInField;
    public bool IsAlive { get; private set; }

    private void Start()
    {
        _screenaspectCounter = GetComponent<ScreenAspectCounter>();
        _scaleValue = _scaleCooficeent * _screenaspectCounter.ScreenWidth;
        transform.localScale = new Vector3(_scaleValue, 1, 0);

        _isInField = false;
        _currentPosition = transform.position;
        IsAlive = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<BlackHole>(out BlackHole blackHole))
        {
            PlayerPrefs.SetFloat("BlackHoleRed", blackHole.GetComponent<SpriteRenderer>().color.r);
            PlayerPrefs.SetFloat("BlackHoleGreen", blackHole.GetComponent<SpriteRenderer>().color.g);
            PlayerPrefs.SetFloat("BlackHoleBlue", blackHole.GetComponent<SpriteRenderer>().color.b);
            IsAlive = false;
            _onBlackHoleCollision?.Invoke();
        }
        if (collision.TryGetComponent<BlackholeGravityField>(out BlackholeGravityField field))
        {
            Vector3 targetPosition = new Vector3(_currentPosition.x, _currentPosition.y - 2, 0);
            if (_isInField && transform.position == targetPosition)
                SceneManager.LoadScene("Lose screen");
            transform.DOMove(targetPosition, _durationOfMoveDown);
            _isInField = true;
        }
        if (collision.TryGetComponent<Pit>(out Pit pit))
        {
            IsAlive = false;
            _onPitCollision?.Invoke();
        }
        if (collision.TryGetComponent<EnergyBarrier>(out EnergyBarrier energyBarrier))
        {
            IsAlive = false;
            _onEnergyBarrierCollision?.Invoke();
        }
    }
    private void OnDestroy()
    {
        transform.DOKill();
    }
}
