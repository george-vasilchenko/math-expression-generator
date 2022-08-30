namespace Meg.Ui.Expressions
{
    public sealed class EqualityExpression : OperationExpression<double, bool>, IEquatable<EqualityExpression>
    {
        public EqualityExpression(Expression<double> lhs, Expression<double> rhs)
            : base(OperationType.Equality, lhs, rhs)
        {
        }

        public Expression<double> Lhs => Expressions[0];

        public Expression<double> Rhs => Expressions[1];

        public bool Equals(EqualityExpression? other) => ToString().Equals(other!.ToString());

        public override Func<bool> ToFunc() => () => Lhs.ToFunc().Invoke() == Rhs.ToFunc().Invoke();

        public override string ToString() => $"{Lhs.ToString()} = {Rhs.ToString()}";
    }
}
