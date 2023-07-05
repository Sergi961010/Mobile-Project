using System.Collections;
using TheCreators.CustomEventSystem;
using UnityEngine;

namespace TheCreators
{
    public class AlertController : MonoBehaviour
    {
        private BlinkEffect _blinkEffect;
        [SerializeField] private float _autoDisableTimer;
        private void Awake()
        {
            _blinkEffect = GetComponent<BlinkEffect>();
        }
        private void OnEnable()
        {
            StartCoroutine(AutoDisable());
            _blinkEffect.StartBlinking();
        }
        private IEnumerator AutoDisable()
        {
            yield return new WaitForSeconds(_autoDisableTimer);
            _blinkEffect.StopBlinking();
            gameObject.SetActive(false);
            GameEvent.OnAlertFinished.Invoke();
        }
    }
}
