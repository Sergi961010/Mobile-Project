using TheCreators.EventSystem;
using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Platforms
{
    public class PlatformController : MonoBehaviour
    {
        private readonly float SPAWN_OFFSET = 5;
        private float _rightBoundaryPosition;
        private float _cameraRightBoundary;
        private BoxCollider2D _collider;
        private bool didSpawnNewPlatform = false;
        private void Awake()
        {
            _cameraRightBoundary = Camera.main.orthographicSize * Screen.width / Screen.height;
            _collider = GetComponent<BoxCollider2D>();
        }

        private void FixedUpdate()
        {
            _rightBoundaryPosition = transform.position.x + (_collider.size.x / 2);

            Move();
            DeactivateWhenOutOfCamera();
            SpawnNewPlatformWhenInsideOfCamera();
        }

        private void Move()
        {
            Vector2 newPosition = transform.position;
            newPosition.x -= 2f * Time.fixedDeltaTime;
            transform.position = newPosition;
        }

        private void SpawnNewPlatformWhenInsideOfCamera()
        {
            if (_rightBoundaryPosition <= _cameraRightBoundary + SPAWN_OFFSET)
            {
                GameEvent.onPlatformSpawn.Invoke(transform.position);
            }
        }

        private void DeactivateWhenOutOfCamera()
        {
            if (_rightBoundaryPosition < -_cameraRightBoundary)
            {
                gameObject.SetActive(false);
            }
        }
    }
}