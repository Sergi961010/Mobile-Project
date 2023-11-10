using System.Collections;
using System.Collections.Generic;
using TheCreators.Input;
using TheCreators.Utilities;
using UnityEngine;

namespace TheCreators.CoreSystem.CoreComponents
{
    public class InputController : BaseCoreComponent
    {
        [SerializeField] private InputReader _inputReader;

        [Header("Jump Settings")]
        [SerializeField] private float _jumpInputBufferTime = 0.2f;

        [Header("Dig Settings")]
        [SerializeField] private float _digInputCooldownTime = 0.1f;
        [SerializeField] private float _digInputBufferTime = 0.2f;

        private List<Timer> timers;
        private CountdownTimer _jumpInputBufferTimer;
        private CountdownTimer _burrowInputBufferTimer;
        private CountdownTimer _unburrowInputBufferTimer;
        private CountdownTimer _burrowInputCooldownTimer;
        private CountdownTimer _unburrowInputCooldownTimer;

        public bool CanJump { get; private set; }
        public bool IsFlying { get; private set; }
        public bool CanBurrow { get; private set; }
        public bool CanUnburrow { get; private set; }
        protected override void Awake()
        {
            base.Awake();
            EnableInput();
            SetUpControlProperties();
            SetUpTimers();
        }
        private void OnEnable()
        {
            _inputReader.Jump += OnJump;
            _inputReader.Fly += OnFly;
            _inputReader.Burrow += OnBurrow;
            _inputReader.Unburrow += OnUnburrow;
        }
        private void OnDisable()
        {
            _inputReader.Jump -= OnJump;
            _inputReader.Fly -= OnFly;
            _inputReader.Burrow -= OnBurrow;
            _inputReader.Unburrow -= OnUnburrow;
        }
        private void Update()
        {
            foreach (var timer in timers)
            {
                timer.Tick(Time.deltaTime);
            }
        }
        private void SetUpTimers()
        {
            _jumpInputBufferTimer = new CountdownTimer(_jumpInputBufferTime);
            _burrowInputBufferTimer = new CountdownTimer(_digInputBufferTime);
            _unburrowInputBufferTimer = new CountdownTimer(_digInputBufferTime);
            _burrowInputCooldownTimer = new CountdownTimer(_digInputCooldownTime);
            _unburrowInputCooldownTimer = new CountdownTimer(_digInputCooldownTime);

            _jumpInputBufferTimer.OnTimerStart += () => CanJump = true;
            _jumpInputBufferTimer.OnTimerStop += () => CanJump = false;

            _burrowInputBufferTimer.OnTimerStart += () => CanBurrow = true;
            _burrowInputBufferTimer.OnTimerStop += () => CanBurrow = false;
            _unburrowInputBufferTimer.OnTimerStart += () => CanUnburrow = true;
            _unburrowInputBufferTimer.OnTimerStop += () => CanUnburrow = false;

            _burrowInputCooldownTimer.OnTimerStart += () => CanBurrow = false;
            _unburrowInputCooldownTimer.OnTimerStart += () => CanUnburrow = false;
            timers = new(5) { _jumpInputBufferTimer, _burrowInputBufferTimer, _unburrowInputBufferTimer, _burrowInputCooldownTimer, _unburrowInputCooldownTimer };
        }
        private void SetUpControlProperties()
        {
            CanJump = false;
            IsFlying = false;
            CanBurrow = false;
            CanUnburrow = false;
        }
        private void OnJump()
        {
            _jumpInputBufferTimer.Start();
        }
        private void OnFly(bool performed)
        {
            Debug.Log(Core.CollisionSenses.CanFly);
            if (performed && Core.CollisionSenses.CanFly) IsFlying = true;
            else IsFlying = false;
        }
        private void OnBurrow()
        {
            if (_burrowInputCooldownTimer.IsFinished)
            {
                _burrowInputBufferTimer.Start();
                _unburrowInputCooldownTimer.Start();
            }
        }
        private void OnUnburrow()
        {
            if (_unburrowInputCooldownTimer.IsFinished)
            {
                _unburrowInputBufferTimer.Start();
                _burrowInputCooldownTimer.Start();
            }
        }
        public void EnableInput()
        {
            _inputReader.GameInput.Enable();
        }
        public void DisableInput()
        {
            _inputReader.GameInput.Disable();
        }
    }
}