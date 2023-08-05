using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _time;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _targetColor;

    private float _runningTime;
    private float _screenWidth;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = _startColor;

        float screenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        _screenWidth = screenAspect * cameraHeight;
        transform.localScale = new Vector3(_screenWidth, 0.3f, 0);
    }

    private void Update()
    {
        _runningTime += Time.deltaTime;
        if (_runningTime < _time)
        {
            float newX = Mathf.Lerp(0, -_screenWidth, _runningTime/_time);
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);

            _spriteRenderer.color = Color.Lerp(_startColor, _targetColor, _runningTime / _time);
        }
    }
}
