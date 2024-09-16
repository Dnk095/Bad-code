using UnityEngine;

public class GoPlaces : MonoBehaviour
{
    [SerializeField] private Transform _placesPoint;
    [SerializeField] private float _speed;
    [SerializeField] private int _targetNumber;

    private Transform[] _places;

    private void Start()
    {
        _places = new Transform[_placesPoint.childCount];

        for (int i = 0; i < _placesPoint.childCount; i++)
            _places[i] = _placesPoint.GetChild(i);
    }

    private void Update()
    {
        Transform targetPoint = _places[_targetNumber];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == targetPoint.position)
            TakeNextTarget();
    }

    private void TakeNextTarget()
    {
        _targetNumber = (_targetNumber + 1) % _places.Length;

        Vector3 nextPosition = _places[_targetNumber].transform.position;
        transform.forward = nextPosition - transform.position;
    }
}