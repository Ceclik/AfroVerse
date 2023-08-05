using UnityEngine;

public class ScreenAspectCounter : MonoBehaviour
{
    public float ScreenWidth { get; private set; }
    public float ScreenAspect { get; private set;}

    private void Awake()
    {
        ScreenAspect = (float)Screen.width / Screen.height;
        float cameraHeight = Camera.main.orthographicSize * 2;
        ScreenWidth = ScreenAspect * cameraHeight;
    }
}
