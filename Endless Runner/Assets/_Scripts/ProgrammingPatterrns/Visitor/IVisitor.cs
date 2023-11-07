using TheCreators.CoreSystem.CoreComponents;

namespace TheCreators.ProgrammingPatterns.Visitor
{
    public interface IVisitor
    {
        void Visit(StaminaComponent staminaComponent);
    }
}