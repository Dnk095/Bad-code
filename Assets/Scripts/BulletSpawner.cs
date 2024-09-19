using System.Collections;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private Transform _shootTarger;
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
            Bullet bullet = Instantiate(_bulletPrefab, transform.position + direction, Quaternion.identity);

            bullet.Move(direction);

            yield return wait;
        }
    }
}