using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace TheCreators
{
    public class BlinkEffect : MonoBehaviour
    {
        [SerializeField] private float _delay = .2f;
        private Image _image;
        private void Awake()
        {
            _image = GetComponent<Image>();
        }
        private IEnumerator Blink()
        {
            while (true)
            {
                _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 0);
                yield return new WaitForSeconds(_delay);
                _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 1);
                yield return new WaitForSeconds(_delay);
            }
            
        }
        public void StartBlinking()
        {
            StartCoroutine(Blink());
        }
        public void StopBlinking()
        {
            StopCoroutine(Blink());
        }
    }
}
