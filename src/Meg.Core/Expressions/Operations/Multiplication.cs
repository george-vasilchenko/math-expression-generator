using Meg.Core.Presentations;

namespace Meg.Core.Expressions.Operations
{
    public class Multiplication : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor visitor;

        public Multiplication(IExpressionFormatVisitor visitor, params NumericExpression[] expressions)
            : base(OperationType.Multiplication, expressions) => this.visitor = visitor;

        public override double Compute()
        {
            var result = Expressions[0].Compute();

            for (var i = 1; i < Expressions.Length; i++)
            {
                var exp = Expressions[i];
                var value = exp.Compute();
                result *= value;
            }

            return result;
        }

        public override string ToFormat() => visitor.Visit(this);
    }
}