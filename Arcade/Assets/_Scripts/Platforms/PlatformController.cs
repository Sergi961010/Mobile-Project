using TheCreators.EventSystem;
using UnityEngine;

namespace TheCreators.Platforms
{
    public class PlatformController : MonoBehaviour
    {
        private float _rightBoundaryPosition;
        private float _cameraRightBoundary;
        private BoxCollider2D _collider;
        private bool _didSpawn;

        private void Awake()
        {
            _cameraRightBoundary = Camera.main.orthographicSize * Screen.width / Screen.height;
            _collider = GetComponent<BoxCollider2D>();
        }

        private void OnEnable()
        {
            _didSpawn = false;  
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
            if (_rightBoundaryPosition <= _cameraRightBoundary)
            {
                if (!_didSpawn)
                {
                    Vector2 currentPosition = new(_rightBoundaryPosition, transform.position.y);
                    GameEvent.onPlatformSpawn.Invoke(currentPosition);
                    _didSpawn = true;
                }
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