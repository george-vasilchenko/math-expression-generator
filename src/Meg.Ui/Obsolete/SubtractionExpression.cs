namespace ExprGenerator
{
    public class SubtractionExpression : BinaryOperationExpression<double, double>
    {
        public SubtractionExpression(Expression<double> lhs, Expression<double> rhs) : base(lhs, OperationType.Subtraction, rhs)
        {
        }

        public override Func<double> ToFunc() => () => Lhs.ToFunc().Invoke() - Rhs.ToFunc().Invoke();

        public override string ToString()
        {
            string GetRhsBasedOnSign() => Rhs.ToFunc().Invoke() < 0 ? $"({Rhs.ToString()})" : Rhs.ToString();

            return $"{Lhs.ToString()} {GetOperationString()} {GetRhsBasedOnSign()}";
        }
    }
}
