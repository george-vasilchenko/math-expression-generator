using Meg.Ui.Presentations;

namespace Meg.Ui.Expressions
{
    public class Sum : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;

        private Sum(IExpressionFormatVisitor expressionFormatVisitor, bool hasParenthesis, params Expression<double>[] expressions)
            : base(OperationType.Sum, expressions)
        {
            this.expressionFormatVisitor = expressionFormatVisitor;
            HasParenthesis = hasParenthesis;
        }

        public bool HasParenthesis { get; } = false;

        public static Sum New(IExpressionFormatVisitor expressionFormatVisitor, params Expression<double>[] expressions)
        {
            return new Sum(expressionFormatVisitor, false, expressions);
        }

        public static Sum NewWithParenthesis(IExpressionFormatVisitor expressionFormatVisitor, params Expression<double>[] expressions)
        {
            return new Sum(expressionFormatVisitor, true, expressions);
        }

        public override string ToFormat() => expressionFormatVisitor.Visit(this);

        public override Func<double> ToResultFunc() => () => Expressions.Sum(e => e.ToResultFunc().Invoke());
    }
}
