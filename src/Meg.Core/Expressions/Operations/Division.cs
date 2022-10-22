using Meg.Core.Presentations;

namespace Meg.Core.Expressions.Operations
{
    public class Division : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;

        public Division(IExpressionFormatVisitor expressionFormatVisitor, bool hasParenthesis, params NumericExpression[] expressions)
            : base(OperationType.Division, expressions)
        {
            if (expressions is null)
            {
                throw new ArgumentNullException(nameof(expressions));
            }

            this.expressionFormatVisitor = expressionFormatVisitor ?? throw new ArgumentNullException(nameof(expressionFormatVisitor));
            HasParenthesis = hasParenthesis;
            IsFraction = false;
        }

        public Division(IExpressionFormatVisitor expressionFormatVisitor, bool hasParenthesis, NumericExpression numerator, NumericExpression denominator)
            : base(OperationType.Division, numerator, denominator)
        {
            if (numerator is null)
            {
                throw new ArgumentNullException(nameof(numerator));
            }

            if (denominator is null)
            {
                throw new ArgumentNullException(nameof(denominator));
            }

            this.expressionFormatVisitor = expressionFormatVisitor ?? throw new ArgumentNullException(nameof(expressionFormatVisitor));
            HasParenthesis = hasParenthesis;
            IsFraction = true;
        }

        public bool HasParenthesis { get; } = false;
        public bool IsFraction { get; } = false;

        public override double Compute()
        {
            var result = Expressions[0].Compute();

            for (var i = 1; i < Expressions.Length; i++)
            {
                var exp = Expressions[i];
                var value = exp.Compute();
                result /= value;
            }

            return result;
        }

        public override string ToFormat() => expressionFormatVisitor.Visit(this);
    }
}