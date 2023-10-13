using TheCreators.CoreSystem.CoreComponents;
using TheCreators.Player;
using TheCreators.Player.Input;
using TheCreators.Player.StateMachine;
using TheCreators.Player.StateMachine.States;
using UnityEngine;

namespace TheCreators.CoreSystem
{
    public class Core : MonoBehaviour
    {
        public Movement Movement { get; private set; }
        public PlayerInputManager InputManager { get; private set; }
        public StateMachineComponent StateMachine { get; private set; }
        public CollisionSenses CollisionSenses { get; private set; }
        public PlayerAnimator PlayerAnimator { get; private set; }
        public SpriteRendererComponent SpriteRenderer { get; private set; }
        public AudioController AudioController { get; private set; }
        public Death Death { get; private set; }
        public Invulnerability Invulnerability { get; private set; }

        private void Awake()
        {
            Movement = GetComponentInChildren<Movement>();
            InputManager = GetComponentInChildren<PlayerInputManager>();
            StateMachine = GetComponentInChildren<StateMachineComponent>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();
            PlayerAnimator = GetComponentInChildren<PlayerAnimator>();
            SpriteRenderer = GetComponentInChildren<SpriteRendererComponent>();
            Death = GetComponentInChildren<Death>();
            Invulnerability = GetComponentInChildren<Invulnerability>();

        }
    }
}
