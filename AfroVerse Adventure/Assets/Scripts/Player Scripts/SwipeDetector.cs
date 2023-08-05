using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public static event OnSwipeInput SwipeEvent;
    public delegate void OnSwipeInput(Vector2 direcion);

    private float _minSwipeDistance; 
    private Vector2 _tapPosition;
    private Vector2 _swipeDelta;
    private bool _isSwiping;
    private bool _isMobile;


    private void Start()
    {
        _isMobile = Application.isMobilePlatform;
        _isSwiping = false;
        _minSwipeDistance = 80f;
    }

    private void Update()
    {
        if (!_isMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isSwiping = true;
                _tapPosition = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
                ResetSwipe();
        }
        else
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    _isSwiping = true;
                    _tapPosition = Input.GetTouch(0).position;
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled) 
                    ResetSwipe();
            }
        }
        CheckSwipe();
    }

    private void CheckSwipe()
    {
        _swipeDelta = Vector2.zero;
        if(_isSwiping)
        {
            if (!_isMobile && Input.GetMouseButton(0))
            {
                _swipeDelta = (Vector2)Input.mousePosition - _tapPosition;
            }
            else if (Input.touchCount > 0)
                _swipeDelta = Input.GetTouch(0).position - _tapPosition;
        }
        if(_swipeDelta.magnitude > _minSwipeDistance)
        {
            if(SwipeEvent != null)
            {
                if (Mathf.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
                    SwipeEvent(_swipeDelta.x > 0 ? Vector2.right : Vector2.left);
            }
            ResetSwipe();
        }

    }

    private void ResetSwipe()
    {
        _isSwiping = false;
        _tapPosition = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }
}
