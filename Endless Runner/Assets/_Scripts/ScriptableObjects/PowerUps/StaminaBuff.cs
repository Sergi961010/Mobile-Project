using TheCreators.CoreSystem.CoreComponents;
using UnityEngine;

namespace TheCreators.ScriptableObjects.PowerUps
{
    [CreateAssetMenu(fileName = "StaminaBuff", menuName = "Power Up/Stamina Buff")]
    public class StaminaBuff : PowerUp
    {
        public override void Visit(StaminaComponent staminaComponent)
        {
            staminaComponent.AddStamina(amount);
        }
    }
}
