namespace ExprGenerator
{
    public class SumExpression : BinaryOperationExpression<double, double>
    {
        public SumExpression(Expression<double> lhs, Expression<double> rhs) : base(lhs, OperationType.Sum, rhs)
        {
        }

        public override Func<double> ToFunc() => () => Lhs.ToFunc().Invoke() + Rhs.ToFunc().Invoke();

        public override string ToString()
        {
            string GetRhsBasedOnSign() => Rhs.ToFunc().Invoke() < 0 ? $"({Rhs.ToString()})" : Rhs.ToString();

            return $"{Lhs.ToString()} {GetOperationString()} {GetRhsBasedOnSign()}";
        }
    }
}
