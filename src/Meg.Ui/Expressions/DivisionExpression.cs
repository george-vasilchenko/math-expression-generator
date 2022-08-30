using Meg.Ui.Helpers;

namespace Meg.Ui.Expressions
{
    public class DivisionExpression : OperationExpression<double, double>
    {
        public DivisionExpression(params Expression<double>[] expressions) : base(OperationType.Division, expressions)
        {
        }

        public override Func<double> ToFunc() => () =>
        {
            var result = Expressions[0].ToFunc().Invoke();

            for (var i = 1; i < Expressions.Length; i++)
            {
                var exp = Expressions[i];
                var value = exp.ToFunc().Invoke();
                result /= value;
            }

            return result;
        };

        public override string ToString() => OperationExpressionHelpers.ExpressionsAsDoublesToString(Expressions, GetOperationString());
    }
}
