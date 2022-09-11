namespace Meg.Core.Expressions
{
    public abstract class ComputationExpression<TResult> : Expression
    {
        public abstract TResult Compute();
    }
}
