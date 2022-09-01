namespace Meg.Ui.Expressions
{
    public class Equality : Expression
    {
        private Equality(NumericExpression lhs, NumericExpression rhs, bool isResultHidden = false)
        {
            Lhs = lhs;
            Rhs = rhs;
            IsResultHidden = isResultHidden;
        }

        public bool IsResultHidden { get; }
        public NumericExpression Lhs { get; }
        public NumericExpression Rhs { get; }

        public static Equality New(NumericExpression lhs, NumericExpression rhs)
        {
            return new Equality(lhs, rhs);
        }

        public static Equality NewWithHiddenResult(NumericExpression lhs, NumericExpression rhs)
        {
            return new Equality(lhs, rhs, true);
        }

        public override string ToFormat()
        {
            var rhs = IsResultHidden ? ".." : Rhs.ToFormat();
            return $"{Lhs.ToFormat()} = {rhs}";
        }
    }
}
