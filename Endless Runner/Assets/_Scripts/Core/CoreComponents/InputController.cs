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
        [SerializeField] private float _digInputCooldownTime = 1f;

        private List<Timer> timers;
        private CountdownTimer _jumpInputBufferTimer;
        private CountdownTimer _digInputCooldownTimer;

        public bool CanJump { get; private set; }
        public bool IsFlying { get; private set; }
        public bool CanBurrow { get; private set; }
        public bool CanUnburrow { get; private set; }
        protected override void Awake()
        {
            EnableInput();
            SetUpControlProperties();
            SetUpTimers();
        }
        private void OnEnable()
        {
            _inputReader.Jump += OnJump;
            _inputReader.Fly += OnFly;
            _inputReader.Dig += OnDig;
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
            _digInputCooldownTimer = new CountdownTimer(_digInputCooldownTime);

            _jumpInputBufferTimer.OnTimerStart += () => CanJump = true;
            _jumpInputBufferTimer.OnTimerStop += () => CanJump = false;
            _digInputCooldownTimer.OnTimerStart += LockDig;

            timers = new(2) { _jumpInputBufferTimer, _digInputCooldownTimer };
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
            if (performed) IsFlying = true;
            else IsFlying = false;
        }
        private void OnDig(bool performed)
        {
            if (_digInputCooldownTimer.IsFinished)
            {
                StartCoroutine(OnDigCoroutine(performed));
            }
        }
        private IEnumerator OnDigCoroutine(bool value)
        {
            if (value) CanBurrow = true;
            else CanUnburrow = true;
            yield return new WaitForEndOfFrame();
            _digInputCooldownTimer.Start();
        }
        private void LockDig()
        {
            CanBurrow = false;
            CanUnburrow = false;
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