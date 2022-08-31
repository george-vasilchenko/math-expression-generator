using Meg.Ui.Presentations;

namespace Meg.Ui.Expressions
{
    public class SumExpression : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;

        public bool HasParenthesis { get; } = false;

        public SumExpression(IExpressionFormatVisitor expressionFormatVisitor, params Expression<double>[] expressions)
            : base(OperationType.Sum, expressions)
        {
            this.expressionFormatVisitor = expressionFormatVisitor;
        }

        public SumExpression(IExpressionFormatVisitor expressionFormatVisitor, bool hasParenthesis, params Expression<double>[] expressions)
            : base(OperationType.Sum, expressions)
        {
            this.expressionFormatVisitor = expressionFormatVisitor;
            HasParenthesis = hasParenthesis;
        }

        public override Func<double> ToResultFunc() => () => Expressions.Sum(e => e.ToResultFunc().Invoke());

        public override string ToFormat() => expressionFormatVisitor.Visit(this);
    }
}
