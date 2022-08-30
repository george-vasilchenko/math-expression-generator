namespace ExprGenerator
{
    public abstract class OperationExpression<TResult> : Expression<TResult>
            where TResult : struct
    {
        protected OperationExpression(OperationType operationType) => OperationType = operationType;

        public OperationType OperationType { get; }

        public string GetOperationString() => OperationType switch
        {
            OperationType.Sum => "+",
            OperationType.Subtraction => "-",
            OperationType.Multiplication => "*",
            OperationType.Division => ":",
            OperationType.Equality => "=",
            _ => throw new ArgumentException("Unexpected operation case."),
        };
    }
}
