using UnityEngine;
using Cinemachine;

public class Parallax : MonoBehaviour
{
    private Camera _camera;
    [SerializeField] private Transform _player;
    private float _startPositionX;
    private float _startZ, _spriteWidth;
    private float DistanceFromPlayer => transform.position.z - _player.position.z;
    private float ClippingPlane => _camera.transform.position.z + (DistanceFromPlayer > 0 ? _camera.farClipPlane : _camera.nearClipPlane);
    private float ParallaxFactor => Mathf.Abs(DistanceFromPlayer / ClippingPlane);
    private float TravelDistance => _camera.transform.position.x * ParallaxFactor;
    private float OffsetDistance => _camera.transform.position.x * (1 - ParallaxFactor);
    void Start()
    {
        _startPositionX = transform.position.x;
        _startZ = transform.position.z;
        _spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        _camera = Camera.main;
    }
    void Update()
    {
        transform.position = new Vector3(_startPositionX + TravelDistance, transform.position.y, _startZ);
        if (OffsetDistance > _startPositionX + _spriteWidth)
        {
            _startPositionX += _spriteWidth;
        }
    }
}