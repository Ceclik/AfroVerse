using System.Collections;
using UnityEngine;

[RequireComponent(typeof(ScreenAspectCounter))]
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _blackHole;
    [SerializeField] private SpriteRenderer _blackholeSpriteRenderer;

    [SerializeField] private GameObject _pit;

    [SerializeField] private GameObject _energyBarrier;

    [SerializeField] private float _deltaSpawnTime;

    private int _choiceOfEnemy;

    private ScreenAspectCounter _screenAspectCounter;
    private const float _scaleCooficeent = 0.12f;
    private const float _energyBarrierScaleCooficeent = 0.25f;
    private float _newScaleValue;
    private float _newEnergyBarrierScaleValue;

    private void Start()
    {
        _screenAspectCounter = GetComponent<ScreenAspectCounter>();
        _newScaleValue = _scaleCooficeent * _screenAspectCounter.ScreenWidth;
        _newEnergyBarrierScaleValue = _energyBarrierScaleCooficeent * _screenAspectCounter.ScreenWidth;

        _blackholeSpriteRenderer = _blackHole.GetComponent<SpriteRenderer>();
        EnemySpawn();
        StartCoroutine(spawner());
    }

    private IEnumerator spawner()
    {
        yield return new WaitForSeconds(_deltaSpawnTime);
        EnemySpawn();
        StartCoroutine(spawner());
    }

    private void EnemySpawn()
    {
        GameObject newEnemy;
        _choiceOfEnemy = Random.Range(1, 4);
        switch (_choiceOfEnemy)
        {
            case 1:
                _blackholeSpriteRenderer.color = new Color(Random.value, Random.value, Random.value, 1);
                newEnemy = Instantiate(_blackHole, _blackHole.transform.position, Quaternion.identity);
                newEnemy.transform.localScale = new Vector3(_newScaleValue, 0.6f, 0);
                break;
            case 2:
                newEnemy = Instantiate(_pit, _pit.transform.position, Quaternion.identity);
                newEnemy.transform.localScale = new Vector3(_newScaleValue, 0.6f, 0);
                break;
            case 3:
                newEnemy = Instantiate(_energyBarrier, _pit.transform.position, Quaternion.identity);
                newEnemy.transform.localScale = new Vector3(_newEnergyBarrierScaleValue, 1.27f, 0);
                break;
        }
    }
}
