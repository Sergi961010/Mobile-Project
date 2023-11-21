using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.Enviroment
{
    public class SingleElementParallax : MonoBehaviour
    {
        [SerializeField] private float _parallaxFactor;
        private float _gameSpeed;
        private float _spriteWidth;
        void Awake()
        {
            _gameSpeed = GameManager.GameSpeed;
            _spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
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
            if (transform.position.x < -_spriteWidth)
            {
                transform.position = new Vector3(_spriteWidth, 0, 0);
            }
        }
    }
}