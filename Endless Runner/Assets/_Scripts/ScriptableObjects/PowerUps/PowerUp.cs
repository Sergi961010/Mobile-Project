using TheCreators.CoreSystem.CoreComponents;
using TheCreators.ProgrammingPatterns.Visitor;
using UnityEngine;

namespace TheCreators.ScriptableObjects.PowerUps
{
    public abstract class PowerUp : ScriptableObject, IVisitor
    {
        public float amount = 0;
        public abstract void Visit(StaminaComponent staminaComponent);
    }
}