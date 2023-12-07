using TheCreators.CustomEventSystem;
using TheCreators.ProgrammingPatterns.Visitor;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class StaminaComponent : CoreComponent, IVisitable
    {
        private const float MAX_STAMINA = 100f;
        public float CurrentStamina { get; private set; }
        public bool CanRegenerate { get; set; }
        private void Start()
        {
            CurrentStamina = MAX_STAMINA;
            CanRegenerate = false;
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
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
        public void AddStamina(float amount)
        {
            CurrentStamina += amount;
            if (CurrentStamina > MAX_STAMINA) CurrentStamina = MAX_STAMINA;
            GameEventBus.OnStaminaBarUpdate.Invoke(CurrentStamina, MAX_STAMINA);
        }
        public void ResetStaminaBar()
        {
            CurrentStamina = MAX_STAMINA;
            GameEventBus.OnStaminaBarUpdate.Invoke(CurrentStamina, MAX_STAMINA);
        }
    }
}