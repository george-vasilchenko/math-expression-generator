namespace Meg.Ui.Expressions
{
    public sealed class EqualityExpression : OperationExpression<double, bool>
    {
        public EqualityExpression(Expression<double> lhs, Expression<double> rhs)
            : base(OperationType.Equality, lhs, rhs)
        {
        }

        public Expression<double> Lhs => Expressions[0];

        public Expression<double> Rhs => Expressions[1];

        public override Func<bool> ToResultFunc() => () => Lhs.ToResultFunc().Invoke() == Rhs.ToResultFunc().Invoke();

        public override string ToFormat() => $"{Lhs.ToFormat()} = {Rhs.ToFormat()}";
    }
}
