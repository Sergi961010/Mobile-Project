using TheCreators.CoreSystem.CoreComponents;
using TheCreators.ProgrammingPatterns.Visitor;
using UnityEngine;

namespace TheCreators.SpawnSystem
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Stamina Collectible Data", fileName = "new Stamina Collectible Data")]
    public class StaminaCollectibleData : EntityData, IVisitor
    {
        public float amount;
        public void Visit<T>(T visitable) where T : Component, IVisitable
        {
            if (visitable is StaminaComponent staminaComponent)
                staminaComponent.AddStamina(amount);
        }
    }
}