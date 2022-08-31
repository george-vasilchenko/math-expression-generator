using Meg.Ui.Presentations;

namespace Meg.Ui.Expressions
{
    public class SumExpression : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;

        public SumExpression(IExpressionFormatVisitor expressionFormatVisitor, params Expression<double>[] expressions)
            : base(OperationType.Sum, expressions)
        {
            this.expressionFormatVisitor = expressionFormatVisitor;
        }

        public override Func<double> ToResultFunc() => () => Expressions.Sum(e => e.ToResultFunc().Invoke());

        public override string ToFormat() => expressionFormatVisitor.Visit(this);
    }
}
