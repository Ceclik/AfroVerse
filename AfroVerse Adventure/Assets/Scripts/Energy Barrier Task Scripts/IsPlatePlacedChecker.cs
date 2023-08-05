using UnityEngine;
using UnityEngine.Events;

public class IsPlatePlacedChecker : MonoBehaviour
{ 
    [SerializeField] private UnityEvent _onPlatePlaced;

    public bool IsPlatePlaced { get; private set; }

    private void Awake()
    {
        IsPlatePlaced = false;
    }

    public event UnityAction OnPlatePlaced
    {
        add => _onPlatePlaced.AddListener(value);
        remove => _onPlatePlaced.RemoveListener(value);
    }

    private void Update()
    {
        if(transform.childCount != 0)
        {
            IsPlatePlaced = true;
            _onPlatePlaced?.Invoke();
        }
    }
}
