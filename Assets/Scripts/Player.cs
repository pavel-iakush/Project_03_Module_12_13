using UnityEngine;

public class Player : MonoBehaviour
{
    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";
    private KeyCode _jumpButton = KeyCode.Space;

    private Rigidbody _rigidbody;
    private float _xInput;
    private float _zInput;
    private float _deadZone = 0.05f;

    [SerializeField] private float _moveForce;
    [SerializeField] private float _jumpForce;

    [SerializeField] private RigidbodyMove _rigidbodyMove;
    [SerializeField] private RigidbodyJump _rigidbodyJump;
    [SerializeField] private GroundDetector _groundDetector;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _xInput = Input.GetAxisRaw(_horizontalAxis);
        _zInput = Input.GetAxisRaw(_verticalAxis);

        if (IsJumpRequestApproved())
        {
            ValidateJump();
        }
    }

    private void FixedUpdate()
    {
        if (HasHorizontalInput())
            _rigidbodyMove.ProcessMoveLeftRight(_rigidbody, _moveForce, _xInput);

        if (HasVerticalInput())
            _rigidbodyMove.ProcessMoveForwardBackward(_rigidbody, _moveForce, _zInput);

        if (HasJumpPermission())
        {
            _rigidbodyJump.ProcessJump(_rigidbody, _jumpForce);
        }
    }

    private bool HasHorizontalInput()
        => Mathf.Abs(_xInput) > _deadZone;

    private bool HasVerticalInput()
        => Mathf.Abs(_zInput) > _deadZone;

    private bool HasJumpPermission()
        => _rigidbodyJump.IsJumping == true;

    private void ValidateJump()
    {
        _rigidbodyJump.IsJumping = true;
        _groundDetector.IsGrounded = false;
    }

    private bool IsJumpRequestApproved()
        => _rigidbodyJump.IsJumping == false && _groundDetector.IsGrounded == true && Input.GetKeyDown(_jumpButton);
}
