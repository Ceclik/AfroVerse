using UnityEngine;
using UnityEngine.EventSystems;

public class PlatePlacer : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        PlateDragger plate = eventData.pointerDrag.GetComponent<PlateDragger>();
        if (plate)
            plate.DefaultParent = transform; 
    }
}
