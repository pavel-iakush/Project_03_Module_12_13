using UnityEngine;

public class Rotator : MonoBehaviour
{
    private int _minAngle = 200;
    private int _maxAngle = 330;

    private int _rotationSpeed;

    private void Awake()
    {
        _rotationSpeed = Random.Range(_minAngle, _maxAngle);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotationSpeed * Time.deltaTime);
    }
}
