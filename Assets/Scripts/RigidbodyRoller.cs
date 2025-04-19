using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _xInput = Input.GetAxisRaw(_horizontalAxis);
        _zInput = Input.GetAxisRaw(_verticalAxis);

        if (_isJumping == false && Input.GetKeyDown(_jumpButton))
        {
            _isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_xInput) > _deadZone)
        {
            _rigidbody.AddForce(Vector3.right * _moveForce * _xInput, ForceMode.Force);
        }

        if (Mathf.Abs(_zInput) > _deadZone)
        {
            _rigidbody.AddForce(Vector3.forward * _moveForce * _zInput, ForceMode.Force);
        }

        if (_isJumping == true)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumping = false;
        }
    }
}
