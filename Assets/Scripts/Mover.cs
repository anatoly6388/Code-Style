
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _wayPoint;

    private Transform[] _wayPoints;
    private int _currentWaypoint = 0;

    private void Start()
    {
        _wayPoints = new Transform[_wayPoint.childCount];

        for (int i = 0; i < _wayPoints.Length; i++)
            _wayPoints[i] = _wayPoint.GetChild(i);

        _wayPoint = _wayPoints[0];
    }

    private void Update()
    {
        if (transform.position == _wayPoints[_currentWaypoint].position)
            _currentWaypoint = (_currentWaypoint + 1) % _wayPoints.Length;
            _wayPoint= _wayPoints[_currentWaypoint];

        transform.position = Vector3.MoveTowards(transform.position, _wayPoints[_currentWaypoint].position, _speed * Time.deltaTime);
    }
}