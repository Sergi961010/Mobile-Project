using TheCreators.CustomEventSystem;
using UnityEngine;
using UnityEngine.UI;

namespace TheCreators.Player
{
    public class EnergyBarController : MonoBehaviour
    {
        private const float MAX_ENERGY = 100f;

        private float _currentEnergy = 100f;
        public float _energyRegeneration = 5f;
        private float _abilityStaminaCost;

        public bool regenerateStamina = false;

        [SerializeField] private Image _staminaProgressUI;

        private void Update()
        {
            if (regenerateStamina)
            {
                AddStamina();
            } else
            {
                SubstractStamina();
            }
        }
        private void AddStamina()
        {
            _currentEnergy += _energyRegeneration * Time.deltaTime;
            UpdateStaminaBar();
            
            if (_currentEnergy >= MAX_ENERGY)
            {
                regenerateStamina = false;
            }
        }
        private void SubstractStamina()
        {
            _currentEnergy -= _abilityStaminaCost * Time.deltaTime;
            UpdateStaminaBar();

            if (_currentEnergy <= 0)
            {
                regenerateStamina = true;
            }
        }
        private void UpdateStaminaBar()
        {
            _staminaProgressUI.fillAmount = _currentEnergy / MAX_ENERGY;
        }
        public void StaminaAbilityStart(float staminaCost)
        {
            _abilityStaminaCost = staminaCost;
            regenerateStamina = false;
        }
        public void StaminaAbilityEnd()
        {
            _abilityStaminaCost = 0;
            regenerateStamina = true;
        }
    }
}