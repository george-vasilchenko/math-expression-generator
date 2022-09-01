namespace Meg.Ui.Expressions
{
    public abstract class ComputationExpression<TResult> : Expression
    {
        public TResult Compute() => GetComputationFunc().Invoke();

        public abstract Func<TResult> GetComputationFunc();
    }
}
