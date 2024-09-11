using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speedMove;

    private Transform _currentWaypoint;
    private ChickenAnimation _chickenAnimation;

    private bool _isRunning = true;
    private bool _isRight;

    private void Awake()
    {
        _chickenAnimation = GetComponent<ChickenAnimation>();
        _currentWaypoint = _pointA;
        _chickenAnimation.Move(_isRunning);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentWaypoint.position, _speedMove * Time.deltaTime);

        if (Vector2.Distance(transform.position, _currentWaypoint.position) < 0.1f)
        {
            if (_isRight)
            {
                _currentWaypoint = _pointB;
                _isRight = false;
            }
            else
            {
                _currentWaypoint = _pointA;
                _isRight = true;
            }
        }

        Rotate();
    }

    private void Rotate()
    {
        if (transform.position.x >= _currentWaypoint.position.x)
        {
            Quaternion rotate = transform.rotation;
            rotate.y = 0;
            transform.rotation = rotate;
        }

        if (transform.position.x <= _currentWaypoint.position.x)
        {
            Quaternion rotate = transform.rotation;
            rotate.y = 180;
            transform.rotation = rotate;
        }
    }
}