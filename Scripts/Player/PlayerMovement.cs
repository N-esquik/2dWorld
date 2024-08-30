using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private bool _isGround;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
        float moveInput = Input.GetAxis("Horizontal");

        _rigidbody.velocity = new Vector2(moveInput * _speedMove, _rigidbody.velocity.y);
        _animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
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
