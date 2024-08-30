using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private float _speedMove;

    private Transform _currentWaypoint;
    private Animator _animator;

    private bool _isMovingRotate;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _currentWaypoint = _pointA;
        _isMovingRotate = true;
        _animator.SetBool("isRunning", true);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentWaypoint.position, _speedMove * Time.deltaTime);

        if(Vector2.Distance(transform.position, _currentWaypoint.position) < 0.1f)
        {
            if( _isMovingRotate )
            {
                _currentWaypoint = _pointB;
                _isMovingRotate = false;
            }
            else
            {
                _currentWaypoint = _pointA;
                _isMovingRotate = true;
            }
        }

        Flip();
    }

    private void Flip()
    {
        Vector3 scale = transform.localScale;

        if(transform.position.x > _currentWaypoint.position.x)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        else if(transform.position.x < _currentWaypoint.position.x)
        {
            scale.x = -Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }
}
