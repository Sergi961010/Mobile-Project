using TheCreators.CustomEventSystem;
using UnityEngine;
using UnityEngine.Events;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class Stamina : BaseCoreComponent
    {
        private const float MAX_STAMINA = 100f;
        public float CurrentStamina { get; private set; }
        private readonly float _regenerationValue = 5f;
        public bool CanRegenerate { get; set; }
        private void Start()
        {
            CurrentStamina = MAX_STAMINA;
            CanRegenerate = false;
        }
        private void Update()
        {
            if (CanRegenerate && CurrentStamina < MAX_STAMINA)
            {
                AddStamina();
            }
        }
        private void AddStamina()
        {
            CurrentStamina += _regenerationValue * Time.deltaTime;
            GameEventBus.OnStaminaBarUpdate.Invoke(CurrentStamina, MAX_STAMINA);
            if (CurrentStamina >= MAX_STAMINA)
            {
                CurrentStamina = MAX_STAMINA;
            }
        }
        public void SubstractStamina(float value)
        {
            CurrentStamina -= value * Time.deltaTime;
            GameEventBus.OnStaminaBarUpdate.Invoke(CurrentStamina, MAX_STAMINA);
            if (CurrentStamina <= 0)
            {
                CurrentStamina = 0;
            }
        }
    }
}