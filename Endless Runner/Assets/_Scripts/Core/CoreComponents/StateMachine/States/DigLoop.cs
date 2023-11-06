using TheCreators.Managers;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents.StateMachine
{
    [CreateAssetMenu(fileName = "DigLoopState", menuName = "PlayerStates/Dig/DigLoop")]
    public class DigLoop : PlayerState
    {
        private readonly PlayerAnimator _playerAnimator;
        private PlayerAnimator PlayerAnimator
        {
            get => _playerAnimator != null ? _playerAnimator : _context.GetCoreComponent<PlayerAnimator>();
        }
        private readonly InputController _inputController;
        private InputController InputController
        {
            get => _inputController != null ? _inputController : _context.GetCoreComponent<InputController>();
        }
        private readonly Stamina _stamina;
        private Stamina Stamina
        {
            get => _stamina != null ? _stamina : _context.GetCoreComponent<Stamina>();
        }
        private readonly StateMachineComponent _stateMachine;
        private StateMachineComponent StateMachine
        {
            get => _stateMachine != null ? _stateMachine : _context.GetCoreComponent<StateMachineComponent>();
        }
        public float staminaCost = 20f;
        public override void Enter()
        {
            PlayerAnimator.PlayLockedAnimation(animations[0]);
            SoundManager.Instance.PlayLoopedAudioEvent(audioEvent);
        }
        public override void Exit()
        {
            SoundManager.Instance.StopLoopedAudioEvent();
        }
        public override void LogicUpdate()
        {
            Stamina.SubstractStamina(staminaCost);
            if (InputController.CanUnburrow || Stamina.CurrentStamina == 0) 
                TransitionToDigExit();
        }
        public override void PhysicsUpdate()
        {
        }
        private void TransitionToDigExit()
        {
            StateMachine.StateMachine.SwitchState(StateMachine.digExitState);
        }
    }
}