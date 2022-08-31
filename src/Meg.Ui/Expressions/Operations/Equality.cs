namespace Meg.Ui.Expressions
{
    public class Equality : OperationExpression<double, bool>
    {
        private Equality(Expression<double> lhs, Expression<double> rhs, bool isResultHidden = false)
            : base(OperationType.Equality, lhs, rhs)
        {
            IsResultHidden = isResultHidden;
        }

        public bool IsResultHidden { get; }

        public Expression<double> Lhs => Expressions[0];

        public Expression<double> Rhs => Expressions[1];

        public static Equality New(Expression<double> lhs, Expression<double> rhs)
        {
            return new Equality(lhs, rhs);
        }

        public static Equality NewWithHiddenResult(Expression<double> lhs, Expression<double> rhs)
        {
            return new Equality(lhs, rhs, true);
        }

        public override string ToFormat()
        {
            var rhs = IsResultHidden ? ".." : Rhs.ToFormat();
            return $"{Lhs.ToFormat()} = {rhs}";
        }

        public override Func<bool> ToResultFunc() => () => Lhs.ToResultFunc().Invoke() == Rhs.ToResultFunc().Invoke();
    }
}
