using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    private bool _isGrounded = true;

    public bool IsGrounded
    {
        get
        {
            return _isGrounded;
        }
        set
        {
            _isGrounded = value;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<BoxCollider>() || collision.collider.GetComponent<MeshCollider>())
            _isGrounded = true;
    }
}
