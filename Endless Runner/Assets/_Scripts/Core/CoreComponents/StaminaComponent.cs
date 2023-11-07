using TheCreators.CustomEventSystem;
using TheCreators.ProgrammingPatterns.Visitor;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class StaminaComponent : BaseCoreComponent, IVisitable
    {
        private const float MAX_STAMINA = 100f;
        public float CurrentStamina { get; private set; }
        [SerializeField] private float _regenerationValue = 5f;
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
                RegenerateStamina();
            }
        }
        private void RegenerateStamina()
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
    }
}