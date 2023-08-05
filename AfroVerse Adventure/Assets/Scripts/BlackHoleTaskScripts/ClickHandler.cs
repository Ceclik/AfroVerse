using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandler : MonoBehaviour, IPointerClickHandler
{
    public bool IsClicked { get; private set; }

    private void Start()
    {
        IsClicked = false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        IsClicked = true;
    }
}
