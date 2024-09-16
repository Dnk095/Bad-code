using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _shootTarger;
    [SerializeField] private float _multiplier;
    [SerializeField] private float _timeBetweenShoots;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    private IEnumerator Shoot()
    {
        WaitForSeconds wait = new(_timeBetweenShoots);

        while (enabled)
        {
            Vector3 direction = (_shootTarger.position - transform.position).normalized;
            GameObject bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.transform.up = direction;
            bullet.GetComponent<Rigidbody>().velocity = direction * _multiplier;

            yield return wait;
        }
    }
}