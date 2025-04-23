using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private bool _isGrounded = true;

    public bool IsGrounded => _isGrounded;

    private void OnCollisionEnter(Collision collision)
    {
        if (IsTouchingGround(collision))
            _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (IsTouchingGround(collision))
            _isGrounded = false;
    }

    private bool IsTouchingGround(Collision collision)
        => collision.collider.GetComponent<BoxCollider>() || collision.collider.GetComponent<MeshCollider>();
}