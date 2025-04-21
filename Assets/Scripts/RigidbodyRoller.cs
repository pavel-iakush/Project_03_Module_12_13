using UnityEngine;

public class RigidbodyRoller : MonoBehaviour
{
    private string _horizontalAxis = "Horizontal";
    private string _verticalAxis = "Vertical";
    private KeyCode _jumpButton = KeyCode.Space;

    private Rigidbody _rigidbody;
    [SerializeField] private float _moveForce;
    [SerializeField] private float _jumpForce;
    private float _xInput;
    private float _zInput;
    private float _deadZone = 0.05f;
    private bool _isJumping = false;
    private bool _isGrounded = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _xInput = Input.GetAxisRaw(_horizontalAxis);
        _zInput = Input.GetAxisRaw(_verticalAxis);

        if (IsJumpAllowed())
        {
            _isJumping = true;
            _isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        if (HasHorizontalInput())
            MoveLeftRight();

        if (HasVerticalInput())
            MoveForwardBackward();

        if (CanJump())
            Jump();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<BoxCollider>())
            _isGrounded = true;
    }

    private void MoveLeftRight()
        => _rigidbody.AddForce(Vector3.right * _moveForce * _xInput, ForceMode.Force);

    private void MoveForwardBackward()
        => _rigidbody.AddForce(Vector3.forward * _moveForce * _zInput, ForceMode.Force);

    private void Jump()
    {
        _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        _isJumping = false;
        _isGrounded = false;
    }

    private bool HasHorizontalInput()
        => Mathf.Abs(_xInput) > _deadZone;

    private bool HasVerticalInput()
        => Mathf.Abs(_zInput) > _deadZone;

    private bool CanJump()
        => _isJumping == true;

    private bool IsJumpAllowed()
        => _isJumping == false && _isGrounded == true && Input.GetKeyDown(_jumpButton);
}
