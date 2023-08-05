using UnityEngine;

public class BlackHoleVariantsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _blackHole;

    private Color _originalBlackHoleColor;

    private bool _isTrueColorSpawned;
    private int _falseColorSpawnCounter;

    private void Awake()
    {
        _falseColorSpawnCounter = 0;
        _isTrueColorSpawned = false;
        _originalBlackHoleColor = new Color(PlayerPrefs.GetFloat("BlackHoleRed"), PlayerPrefs.GetFloat("BlackHoleGreen"), PlayerPrefs.GetFloat("BlackHoleBlue"), 1);

        GameObject newBlackHole;
        newBlackHole = Instantiate(_blackHole, new Vector3(-1.38f, 1.24f, 0), Quaternion.identity);
        ColorBlackHole(newBlackHole);
        newBlackHole = Instantiate(_blackHole, new Vector3(1.38f, 1.24f, 0), Quaternion.identity);
        ColorBlackHole(newBlackHole);
        newBlackHole = Instantiate(_blackHole, new Vector3(-1.38f, -1.24f, 0), Quaternion.identity);
        ColorBlackHole(newBlackHole);
        newBlackHole = Instantiate(_blackHole, new Vector3(1.38f, -1.24f, 0), Quaternion.identity);
        ColorBlackHole(newBlackHole);
    }

    private void ColorBlackHole(GameObject newBlackHole)
    {
        int drawRandomColor = (int)Random.Range(0, 2);
        if (drawRandomColor == 1 && _falseColorSpawnCounter < 3)
            DrawRandomColor(newBlackHole);
        else if (drawRandomColor == 0 && _isTrueColorSpawned)
            DrawRandomColor(newBlackHole);
        else if (drawRandomColor == 0 && !_isTrueColorSpawned)
            DrawTrueColor(newBlackHole);
        else if (drawRandomColor == 1 && _falseColorSpawnCounter == 3)
            DrawTrueColor(newBlackHole);
    }

    private void DrawRandomColor(GameObject newBlackHole)
    {
        newBlackHole.GetComponent<SpriteRenderer>().color = new Color(Random.value, Random.value, Random.value, 1);
        _falseColorSpawnCounter++;
    }
    private void DrawTrueColor(GameObject newBlackHole)
    {
        newBlackHole.GetComponent<SpriteRenderer>().color = _originalBlackHoleColor;
        _isTrueColorSpawned = true;
    }
}