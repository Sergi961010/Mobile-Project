using UnityEngine;

namespace TheCreators.ProgrammingPatterns.Visitor
{
    public interface IVisitor
    {
        void Visit<T>(T visitable) where T : Component, IVisitable;
    }
}