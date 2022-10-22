namespace Meg.Core.Expressions
{
    public class Equality : Expression
    {
        public Equality(NumericExpression lhs, NumericExpression rhs, bool isResultHidden = false)
        {
            Lhs = lhs;
            Rhs = rhs;
            IsResultHidden = isResultHidden;
        }

        public bool IsResultHidden { get; }
        public NumericExpression Lhs { get; }
        public NumericExpression Rhs { get; }

        public override string ToFormat()
        {
            var rhs = IsResultHidden ? ".." : Rhs.ToFormat();
            return $"{Lhs.ToFormat()} = {rhs}";
        }
    }
}