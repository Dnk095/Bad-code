using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public void Move(Vector3 direction)
    {
        GetComponent<Rigidbody>().velocity = direction * _speed;
    }
}
