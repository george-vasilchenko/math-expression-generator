using Meg.Ui.Presentations;

namespace Meg.Ui.Expressions
{
    public class Subtraction : OperationExpression<double, double>
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;

        private Subtraction(IExpressionFormatVisitor expressionFormatVisitor, bool hasParenthesis, params NumericExpression[] expressions)
            : base(OperationType.Subtraction, expressions)
        {
            this.expressionFormatVisitor = expressionFormatVisitor;
            HasParenthesis = hasParenthesis;
        }

        public bool HasParenthesis { get; } = false;

        public static Subtraction New(IExpressionFormatVisitor expressionFormatVisitor, params NumericExpression[] expressions)
        {
            return new Subtraction(expressionFormatVisitor, false, expressions);
        }

        public static Subtraction NewWithParenthesis(IExpressionFormatVisitor expressionFormatVisitor, params NumericExpression[] expressions)
        {
            return new Subtraction(expressionFormatVisitor, true, expressions);
        }

        public override string ToFormat() => expressionFormatVisitor.Visit(this);

        public override Func<double> GetComputationFunc() => () =>
                {
                    var result = Expressions[0].GetComputationFunc().Invoke();

                    for (var i = 1; i < Expressions.Length; i++)
                    {
                        var exp = Expressions[i];
                        var value = exp.GetComputationFunc().Invoke();
                        result -= value;
                    }

                    return result;
                };
    }
}
