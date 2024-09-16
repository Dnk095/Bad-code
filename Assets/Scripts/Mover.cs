using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Transform _placesConteiner;
    [SerializeField] private float _speed;
    [SerializeField] private int _targetIndex;

    private Transform[] _places;

    private void Start()
    {
        _places = new Transform[_placesConteiner.childCount];

        for (int i = 0; i < _places.Length; i++)
            _places[i] = _placesConteiner.GetChild(i);
    }

    private void Update()
    {
        Transform targetPoint = _places[_targetIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

        if (transform.position == targetPoint.position)
            ChangeTarget();
    }

    private void ChangeTarget()
    {
        _targetIndex = ++_targetIndex % _places.Length;

        transform.forward = _places[_targetIndex].transform.position - transform.position;
    }
}