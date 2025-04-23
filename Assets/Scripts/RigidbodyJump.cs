using UnityEngine;

public class RigidbodyJump : MonoBehaviour
{
    private ForceMode _forceMode = ForceMode.Impulse;

    public void ProcessJump(Rigidbody rigidbody, float jumpForce)
    {
        rigidbody.AddForce(Vector3.up * jumpForce, _forceMode);
    }
}
