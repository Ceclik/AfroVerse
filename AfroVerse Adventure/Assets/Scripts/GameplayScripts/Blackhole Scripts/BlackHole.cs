using System.Collections;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private float _timeOfAlive;
    private void Start()
    {
        StartCoroutine(Destroyer());
    }
    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(_timeOfAlive);
        Destroy(gameObject);
    }
}
