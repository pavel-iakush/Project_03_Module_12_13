using UnityEngine;

public class Rotator : MonoBehaviour
{
    private int _minAngle = 200;
    private int _maxAngle = 330;

    private int rotation;

    private void Awake()
    {
        rotation = Random.Range(_minAngle, _maxAngle);
    }

    private void Update()
    {
        transform.Rotate(Vector3.up, rotation * Time.deltaTime);
    }
}
