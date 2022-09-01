using Meg.Ui.Presentations;

namespace Meg.Ui.Expressions
{
    public class Multiplication : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor visitor;

        private Multiplication(IExpressionFormatVisitor visitor, params NumericExpression[] expressions)
            : base(OperationType.Multiplication, expressions)
        {
            this.visitor = visitor;
        }

        public static Multiplication New(IExpressionFormatVisitor visitor, params NumericExpression[] expressions)
        {
            return new Multiplication(visitor, expressions);
        }

        public override Func<double> GetComputationFunc() => () =>
                {
                    var result = Expressions[0].Compute();

                    for (var i = 1; i < Expressions.Length; i++)
                    {
                        var exp = Expressions[i];
                        var value = exp.Compute();
                        result *= value;
                    }

                    return result;
                };

        public override string ToFormat() => visitor.Visit(this);
    }
}
