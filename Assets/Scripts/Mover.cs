using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _placesPoint;
    [SerializeField] private float _speed;
    [SerializeField] private int _targetIndex;

    private Transform[] _places;

    private void Start()
    {
        _places = new Transform[_placesPoint.childCount];

        for (int i = 0; i < _placesPoint.childCount; i++)
            _places[i] = _placesPoint.GetChild(i);
    }

    private void Update()
    {
        Transform targetPoint = _places[_targetIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == targetPoint.position)
            TakeNextTarget();
    }

    private void TakeNextTarget()
    {
        _targetIndex = (_targetIndex + 1) % _places.Length;

        Vector3 nextPosition = _places[_targetIndex].transform.position;
        transform.forward = nextPosition - transform.position;
    }
}