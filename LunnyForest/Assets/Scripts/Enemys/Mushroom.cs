using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class Mushroom : MonoBehaviour
{
    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value;
            _animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public bool CanMove => _animator.GetBool(AnimationStrings.canMove);

    [SerializeField] private float _walkSpeed = 3f;
    [SerializeField] private DetectionArea _detectionArea;
    [SerializeField] private float _walkStopRate = 0.05f;
    private Rigidbody2D _rigidbody2D;
    private TouchingDirections _touchingDirections;
    private WalkableDirection _walkDirection;
    private Animator _animator;
    private Vector2 _walkDirectionVector = Vector2.right;
    private bool _hasTarget;

    public WalkableDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if (_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1,
                    gameObject.transform.localScale.y);
                if (value == WalkableDirection.Right)
                {
                    _walkDirectionVector = Vector2.right;
                }
                else if (value == WalkableDirection.Left)
                {
                    _walkDirectionVector = Vector2.left;
                }
            }

            _walkDirection = value;
        }
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _touchingDirections = GetComponent<TouchingDirections>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HasTarget = _detectionArea.detectedColliders.Count > 0;
    }

    private void FixedUpdate()
    {
        if (_touchingDirections.IsGrounded && _touchingDirections.IsOnWall)
        {
            FlipDirection();
        }

        if (CanMove)
        {
            _rigidbody2D.velocity = new Vector2(_walkSpeed * _walkDirectionVector.x, _rigidbody2D.velocity.y);
        }
        else
        {
            _rigidbody2D.velocity = new Vector2(Mathf.Lerp(_rigidbody2D.velocity.x, 0, _walkStopRate), _rigidbody2D.velocity.y);
        }
    }

    private void FlipDirection()
    {
        if (_walkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }
        else if (WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
        else
        {
            Debug.Log("Нет значения для движения в стороны");
        }
    }

    public enum WalkableDirection
    {
        Right,
        Left
    }
}