using Meg.Ui.Presentations;

namespace Meg.Ui.Expressions
{
    public class Division : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;

        private Division(IExpressionFormatVisitor expressionFormatVisitor, bool hasParenthesis, params Expression<double>[] expressions)
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

        private Division(IExpressionFormatVisitor expressionFormatVisitor, bool hasParenthesis, Expression<double> numerator, Expression<double> denominator)
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

        public static Division NewFraction(IExpressionFormatVisitor expressionFormatVisitor, Expression<double> numerator, Expression<double> denominator)
        {
            return new Division(expressionFormatVisitor, false, numerator, denominator);
        }

        public static Division NewFractionWithParenthesis(IExpressionFormatVisitor expressionFormatVisitor, Expression<double> numerator, Expression<double> denominator)
        {
            return new Division(expressionFormatVisitor, true, numerator, denominator);
        }

        public static Division NewInline(IExpressionFormatVisitor expressionFormatVisitor, params Expression<double>[] expressions)
        {
            return new Division(expressionFormatVisitor, false, expressions);
        }

        public static Division NewInlineWithParenthesis(IExpressionFormatVisitor expressionFormatVisitor, params Expression<double>[] expressions)
        {
            return new Division(expressionFormatVisitor, true, expressions);
        }

        public override string ToFormat() => expressionFormatVisitor.Visit(this);

        public override Func<double> ToResultFunc() => () =>
                {
                    var result = Expressions[0].ToResultFunc().Invoke();

                    for (var i = 1; i < Expressions.Length; i++)
                    {
                        var exp = Expressions[i];
                        var value = exp.ToResultFunc().Invoke();
                        result /= value;
                    }

                    return result;
                };
    }
}
