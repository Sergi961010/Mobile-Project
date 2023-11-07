namespace TheCreators.ProgrammingPatterns.Visitor
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}