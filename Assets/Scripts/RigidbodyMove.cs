using UnityEngine;

public class RigidbodyMove : MonoBehaviour
{
    private ForceMode _forceMode = ForceMode.Force;

    public void ProcessMoveLeftRight(Rigidbody rigidbody, float moveForce, float xInput)
        => rigidbody.AddForce(Vector3.right * moveForce * xInput, _forceMode);

    public void ProcessMoveForwardBackward(Rigidbody rigidbody, float moveForce, float zInput)
        => rigidbody.AddForce(Vector3.forward * moveForce * zInput, _forceMode);
}
