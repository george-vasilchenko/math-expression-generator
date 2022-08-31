using Meg.Ui.Presentations;

namespace Meg.Ui.Expressions
{
    public class Subtraction : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;

        private Subtraction(IExpressionFormatVisitor expressionFormatVisitor, bool hasParenthesis, params Expression<double>[] expressions) : base(OperationType.Subtraction, expressions)
        {
            this.expressionFormatVisitor = expressionFormatVisitor;
            HasParenthesis = hasParenthesis;
        }

        public bool HasParenthesis { get; } = false;

        public static Subtraction New(IExpressionFormatVisitor expressionFormatVisitor, params Expression<double>[] expressions)
        {
            return new Subtraction(expressionFormatVisitor, false, expressions);
        }

        public static Subtraction NewWithParenthesis(IExpressionFormatVisitor expressionFormatVisitor, params Expression<double>[] expressions)
        {
            return new Subtraction(expressionFormatVisitor, true, expressions);
        }

        public override string ToFormat() => expressionFormatVisitor.Visit(this);

        public override Func<double> ToResultFunc() => () =>
                {
                    var result = Expressions[0].ToResultFunc().Invoke();

                    for (var i = 1; i < Expressions.Length; i++)
                    {
                        var exp = Expressions[i];
                        var value = exp.ToResultFunc().Invoke();
                        result -= value;
                    }

                    return result;
                };
    }
}
