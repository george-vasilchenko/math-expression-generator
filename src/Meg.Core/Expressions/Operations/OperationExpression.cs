namespace Meg.Core.Expressions.Operations
{
    public abstract class OperationExpression<TInput, TResult> : NumericExpression
    {
        protected OperationExpression(OperationType operationType, params NumericExpression[] expressions)
        {
            if (expressions.Length < 2)
            {
                throw new ArgumentException("Minimal length of expression array is 2");
            }

            OperationType = operationType;
            Expressions = expressions;
        }

        public NumericExpression[] Expressions { get; }

        public OperationType OperationType { get; }
    }
}
