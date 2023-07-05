using System.Collections;
using UnityEngine;

namespace TheCreators.Obstacles
{
    public class LaserController : MonoBehaviour
    {
        [SerializeField] private GameObject _alertComponent, _killAreaComponent;
        [SerializeField] private float _alertTimer = 1f, _killAreaTimer = 2f;
        private Camera _camera;
        private void Awake()
        {
            _camera = Camera.main;
        }
        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_alertTimer);
            _alertComponent.SetActive(false);
            _killAreaComponent.SetActive(true);
            yield return new WaitForSeconds(_killAreaTimer);
            Destroy(gameObject);
        }
        private void Update()
        {
            transform.position = new Vector2 (_camera.transform.position.x, transform.position.y);
        }
    }
}
