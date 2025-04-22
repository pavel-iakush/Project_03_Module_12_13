using UnityEngine;

public class RigidbodyJump : MonoBehaviour
{
    private ForceMode _forceMode = ForceMode.Impulse;
    private bool _isJumping = false;

    public bool IsJumping
    {
        get
        {
            return _isJumping;
        }
        set
        {
            _isJumping = value;
        }
    }

    public void ProcessJump(Rigidbody rigidbody, float jumpForce)
    {
        rigidbody.AddForce(Vector3.up * jumpForce, _forceMode);
        _isJumping = false;
    }
}
