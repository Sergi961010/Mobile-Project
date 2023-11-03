using TheCreators.CoreSystem.CoreComponents;
using UnityEngine;

namespace TheCreators.CoreSystem
{
    public class Core : MonoBehaviour
    {
        public Movement Movement { get; private set; }
        public InputController InputController { get; private set; }
        public StateMachineComponent StateMachine { get; private set; }
        public CollisionSenses CollisionSenses { get; private set; }
        public PlayerAnimator PlayerAnimator { get; private set; }
        public SpriteRendererComponent SpriteRenderer { get; private set; }
        public Death Death { get; private set; }
        public Invulnerability Invulnerability { get; private set; }
        public Stamina Stamina { get; private set; }
        private void Awake()
        {
            Movement = GetComponentInChildren<Movement>();
            InputController = GetComponentInChildren<InputController>();
            StateMachine = GetComponentInChildren<StateMachineComponent>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();
            PlayerAnimator = GetComponentInChildren<PlayerAnimator>();
            SpriteRenderer = GetComponentInChildren<SpriteRendererComponent>();
            Death = GetComponentInChildren<Death>();
            Invulnerability = GetComponentInChildren<Invulnerability>();
            Stamina = GetComponentInChildren<Stamina>();
        }
    }
}
