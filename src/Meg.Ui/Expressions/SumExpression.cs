using Meg.Ui.Helpers;

namespace Meg.Ui.Expressions
{
    public class SumExpression : OperationExpression<double, double>
    {
        public SumExpression(params Expression<double>[] expressions) : base(OperationType.Sum, expressions)
        {
        }

        public override Func<double> ToFunc() => () => Expressions.Sum(e => e.ToFunc().Invoke());

        public override string ToString() => OperationExpressionHelpers.ExpressionsAsDoublesToString(Expressions, GetOperationString());
    }
}
