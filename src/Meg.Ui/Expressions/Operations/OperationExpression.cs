namespace Meg.Ui.Expressions
{
    public abstract class OperationExpression<TInput, TResult> : Expression<TResult>
    {
        protected OperationExpression(OperationType operationType, params Expression<TInput>[] expressions)
        {
            if (expressions.Length < 2)
            {
                throw new ArgumentException("Minimal length of expression array is 2");
            }

            OperationType = operationType;
            Expressions = expressions;
        }

        public Expression<TInput>[] Expressions { get; }

        public OperationType OperationType { get; }
    }
}
