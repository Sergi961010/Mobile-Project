using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Enviroment
{
    public class SingleElementParallax : MonoBehaviour
    {
        [SerializeField] private float _parallaxFactor;
        private float _gameSpeed;
        private float _cameraWidth;
        void Awake()
        {
            _gameSpeed = GameManager.GameSpeed;
            _cameraWidth = CalculateCameraWidth();
        }
        void Update()
        {
            _gameSpeed = GameManager.GameSpeed;
            Scroll();
            CheckReset();
        }
        private void Scroll()
        {
            float delta = _gameSpeed * _parallaxFactor * Time.deltaTime;
            transform.position -= new Vector3(delta, 0, 0);
        }
        private void CheckReset()
        {
            if (transform.position.x < -_cameraWidth)
            {
                transform.position = new Vector3(_cameraWidth, transform.position.y, 0);
            }
        }
        private float CalculateCameraWidth()
        {
            Camera camera = Camera.main;
            float height = camera.orthographicSize * 2f;
            float width = height * camera.aspect;
            return width;
        }
    }
}