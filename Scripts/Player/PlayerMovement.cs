using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    public const string Horizontal = "Horizontal";

    [SerializeField] private float _speedMove;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private PlayerAnimation _playerAnimation;

    private bool _isGround;
    private bool _isRight;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        Move();
        Jump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Ground ground))
        {
            _isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        _isGround = false;
    }

    private void Move()
    {
        float moveInput = Input.GetAxis(Horizontal);

        _rigidbody.velocity = new Vector2(moveInput * _speedMove, _rigidbody.velocity.y);
        _playerAnimation.Move(moveInput);

        Rotate();
    }

    private void Rotate()
    {
        if (Input.GetAxis(Horizontal) > 0)
        {
            _isRight = true;

            Quaternion rotate = transform.rotation;

            rotate.y = 0;
            transform.rotation = rotate;
        }

        if (Input.GetAxis(Horizontal) < 0)
        {
            _isRight = false;
            Quaternion rotate = transform.rotation;
            rotate.y = 180;
            transform.rotation = rotate;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }
    }
}