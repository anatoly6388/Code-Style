using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private float _timeWaitShooting;

    private Transform _objectToShoot;
    private bool isWork = true;

    private void Start()
    {
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        while (isWork)
        {
            var direction = (_objectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;
            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}
