using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _player;
    private Vector3 _velocity = Vector3.zero;
    private float _smoothTime = 0.2f;

    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _player.position, ref _velocity, _smoothTime);
    }
}
