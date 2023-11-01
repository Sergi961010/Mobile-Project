using TheCreators.CoreSystem.CoreComponents;
using TheCreators.Player;
using TheCreators.Input;
using TheCreators.Player.StateMachine;
using TheCreators.Player.StateMachine.States;
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
        public AudioController AudioController { get; private set; }
        public Death Death { get; private set; }
        public Invulnerability Invulnerability { get; private set; }

        private void Awake()
        {
            Movement = GetComponentInChildren<Movement>();
            InputController = GetComponentInChildren<InputController>();
            StateMachine = GetComponentInChildren<StateMachineComponent>();
            CollisionSenses = GetComponentInChildren<CollisionSenses>();
            PlayerAnimator = GetComponentInChildren<PlayerAnimator>();
            SpriteRenderer = GetComponentInChildren<SpriteRendererComponent>();
            AudioController = GetComponentInChildren<AudioController>();
            Death = GetComponentInChildren<Death>();
            Invulnerability = GetComponentInChildren<Invulnerability>();

        }
    }
}
