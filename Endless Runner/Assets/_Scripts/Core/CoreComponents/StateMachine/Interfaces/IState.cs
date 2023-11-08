using TheCreators.CoreSystem;

namespace TheCreators.Player
{
    public interface IState
    {
        public virtual void Init(Core currentContext) {}
        public virtual void Enter() { }
        public virtual void LogicUpdate() { }
        public virtual void PhysicsUpdate() { }
        public virtual void Exit() { }
    }
}
