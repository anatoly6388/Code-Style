using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Bullet _prefab;
    [SerializeField] private float _timeWaitShooting;
    [SerializeField] private Target _target;

    private WaitForSeconds _wait;

    private void Start()
    {
        _wait = new WaitForSeconds(_timeWaitShooting);
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        while (enabled)
        {
            Vector3 direction = (_target.transform. position - transform.position).normalized;
            Bullet newBullet = Instantiate(_prefab, transform.position + direction, Quaternion.identity);
            newBullet.transform.up = direction;
            newBullet.GetComponent<Rigidbody>().velocity = direction * _speed;
            yield return _wait;
        }
    }
}
