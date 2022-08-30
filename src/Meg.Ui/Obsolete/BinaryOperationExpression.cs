namespace ExprGenerator
{
    public abstract class BinaryOperationExpression<TInput, TResult> : OperationExpression<TResult>
        where TInput : struct
        where TResult : struct
    {
        protected BinaryOperationExpression(Expression<TInput> lhs, OperationType operationType, Expression<TInput> rhs)
            : base(operationType)
        {
            Lhs = lhs;
            Rhs = rhs;
        }

        public Expression<TInput> Lhs { get; set; }

        public Expression<TInput> Rhs { get; set; }
    }
}
