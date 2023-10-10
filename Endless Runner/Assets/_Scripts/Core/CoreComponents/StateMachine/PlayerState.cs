using System.Collections.Generic;
using TheCreators.CoreSystem;
using UnityEngine;

namespace TheCreators.Player.StateMachine
{
    public abstract class PlayerState : ScriptableObject, IState
    {
        protected Core _context;
        public List<AnimationClip> _animations;
        public AudioClip _audioClip;
        public virtual void Init(Core currentContext)
        {
            _context = currentContext;
        }
        public virtual void Enter() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void Exit() { }
    }
}