using System.Collections;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    [SerializeField] private float _destroyDeltaTime;
    [SerializeField] private float _speed;

    private Vector3 _targetPosition;

    private void Start()
    {
        StartCoroutine(Destroyer());
    }
    private void Update()
    {
        _targetPosition = new Vector3(transform.position.x, transform.position.y - 12, 0);
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    private IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(_destroyDeltaTime);
        Destroy(gameObject);
    }
}