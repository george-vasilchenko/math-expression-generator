using Meg.Core.Presentations;

namespace Meg.Core.Expressions.Operations
{
    public class Sum : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;

        private Sum(IExpressionFormatVisitor expressionFormatVisitor, bool hasParenthesis, params NumericExpression[] expressions)
            : base(OperationType.Sum, expressions)
        {
            this.expressionFormatVisitor = expressionFormatVisitor;
            HasParenthesis = hasParenthesis;
        }

        public bool HasParenthesis { get; } = false;

        public static Sum New(IExpressionFormatVisitor expressionFormatVisitor, params NumericExpression[] expressions)
        {
            return new Sum(expressionFormatVisitor, false, expressions);
        }

        public static Sum NewWithParenthesis(IExpressionFormatVisitor expressionFormatVisitor, params NumericExpression[] expressions)
        {
            return new Sum(expressionFormatVisitor, true, expressions);
        }

        public override double Compute() => Expressions.Sum(e => e.Compute());

        public override string ToFormat() => expressionFormatVisitor.Visit(this);
    }
}
