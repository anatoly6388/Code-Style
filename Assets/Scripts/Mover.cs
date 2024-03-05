
using UnityEngine;

public class Mover : MonoBehaviour
{
    private float _speed;
    private Transform _wayPoint;
    private Transform[] _wayPoints;
    private int _index;

    private void Start()
    {
        _wayPoints = new Transform[_wayPoint.childCount];

        for (int i = 0; i < _wayPoint.childCount; i++)
            _wayPoints[i] = _wayPoint.GetChild(i).GetComponent<Transform>();
    }

    private void Update()
    {
        var nextPoint = _wayPoints[_index];
        transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, _speed * Time.deltaTime);

        if (transform.position == nextPoint.position) 
            GetDirection();
    }

    public Vector3 GetDirection()
    {
        _index++;

        if (_index == _wayPoints.Length)
                _index = 0;

        var direction = _wayPoints[_index].transform.position;
        transform.forward = direction - transform.position;
        return direction;
    }
}