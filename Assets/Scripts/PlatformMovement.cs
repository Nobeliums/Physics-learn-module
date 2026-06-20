using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    private const float Epsilon = 0.05f;
    
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _moveSpeed;

    private Queue<Transform> _pointsQueue;
    private Transform _currentTarget;

    void Start()
    {
        _pointsQueue = new Queue<Transform>(_points);
        _currentTarget = GetNextTarget();
    }

    void Update()
    {
        MoveToTargetPoint();
    }

    private void MoveToTargetPoint()
    {
        Vector3 direction = _currentTarget.position - transform.position;
        transform.position += direction.normalized * _moveSpeed * Time.deltaTime;

        if (direction.magnitude <= Epsilon)
            _currentTarget = GetNextTarget();
    }

    private Transform GetNextTarget()
    {
        Transform nextTarget = _pointsQueue.Dequeue();
        _pointsQueue.Enqueue(nextTarget);
        return nextTarget;
    }
}
