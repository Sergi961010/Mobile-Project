using System.Collections.Generic;
using UnityEngine;

namespace TheCreators.Player
{
    public abstract class NewPlayerState : ScriptableObject, IState
    {
        protected NewPlayer _context;
        public List<AnimationClip> animations;
        public virtual void Init(NewPlayer currentContext)
        {
            _context = currentContext;
        }
        public virtual void Enter() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void Exit() { }
    }
}