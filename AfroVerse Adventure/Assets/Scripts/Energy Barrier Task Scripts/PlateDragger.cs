using UnityEngine;
using UnityEngine.EventSystems;

public class PlateDragger : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Camera _camera;

    private Vector3 _offset;

    public Transform DefaultParent { get; set; }

    private void Awake()
    {
        _camera = Camera.allCameras[0];
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        _offset = transform.position - _camera.ScreenToWorldPoint(eventData.position); //counting the offset from point of click and pivot of the plate
        _offset.z = 0;
        DefaultParent = transform.parent;
        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPlatePosition = _camera.ScreenToWorldPoint(eventData.position); //creating new position and converting it to global coordinates
        newPlatePosition.z = 0;
        transform.position = newPlatePosition + _offset; //assign new position to position of the plate
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true; 
    }
}
