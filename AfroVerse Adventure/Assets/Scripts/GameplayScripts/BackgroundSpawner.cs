using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ScreenAspectCounter))]

public class BackgroundSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _beginBackground;

    [SerializeField] private float _deltaSpawnTime;

    private ScreenAspectCounter screenAspectCounter;

    private void Start()
    {
        screenAspectCounter = GetComponent<ScreenAspectCounter>();
        var newBackground = Instantiate(_beginBackground, Vector3.zero, Quaternion.identity);

        newBackground.transform.localScale = new Vector3(screenAspectCounter.ScreenWidth, 5, 0);

        newBackground = Instantiate(_beginBackground, new Vector3(0, 10, 0), Quaternion.identity);
        newBackground.transform.localScale = new Vector3(screenAspectCounter.ScreenWidth, 5, 0);

        StartCoroutine(BackgroundSpawn());
    }
    private IEnumerator BackgroundSpawn()
    {
        yield return new WaitForSeconds(_deltaSpawnTime);
        var newBackground = Instantiate(_beginBackground, new Vector3(0, 10, 0), Quaternion.identity);
        newBackground.transform.localScale = new Vector3(screenAspectCounter.ScreenWidth, 5, 0);
        StartCoroutine(BackgroundSpawn());
    }
}
