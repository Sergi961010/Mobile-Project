using TheCreators.CustomEventSystem;
using UnityEngine;
using UnityEngine.UI;

namespace TheCreators.Player
{
    public class EnergyBarController : MonoBehaviour
    {
        private const float MAX_ENERGY = 100f;

        private float _currentEnergy = 100f;
        public float _energyRegeneration = 0.5f;
        public float _flyCost = 0.5f;

        public bool isFlying = false;

        [SerializeField] private Image _staminaProgressUI;

        private void OnEnable()
        {
            GameEvent.OnPerformFly.AddListener(UseAbility);
            GameEvent.OnCancelFly.AddListener(StopAbility);
        }

        private void OnDisable()
        {
            GameEvent.OnPerformFly.RemoveListener(UseAbility);
            GameEvent.OnCancelFly.RemoveListener(StopAbility);
        }


        private void Update()
        {
            if (!isFlying)
            {
                if (_currentEnergy < MAX_ENERGY)
                {
                    _currentEnergy += _energyRegeneration * Time.deltaTime;
                    UpdateStaminaBar();
                }
            }
        }

        private void UpdateStaminaBar()
        {
            _staminaProgressUI.fillAmount = _currentEnergy / MAX_ENERGY;
        }

        public void UseAbility()
        {
            isFlying = true;
            _currentEnergy -= _flyCost * Time.deltaTime;
            UpdateStaminaBar();

            if (_currentEnergy <= 0)
            {
                StopAbility();
            }
        }

        public void StopAbility()
        {
            isFlying = false;
        }
    }
}
