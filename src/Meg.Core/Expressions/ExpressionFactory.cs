using Meg.Core.Expressions.Functions;
using Meg.Core.Expressions.Operations;
using Meg.Core.Expressions.Primitives;
using Meg.Core.Presentations;

namespace Meg.Core.Expressions
{
    public class ExpressionFactory : IExpressionFactory
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;

        public ExpressionFactory(IExpressionFormatVisitor expressionFormatVisitor) => this.expressionFormatVisitor = expressionFormatVisitor;

        public Constant GetConstant(double value) => new(value);

        public Constant GetConstantAsUnknown(double value, string unknown) => new(value, unknown);

        public Constant GetConstantFromExpression(ComputationExpression<double> expression) => new(expression.Compute());

        public Division GetDivisionFraction(NumericExpression numerator, NumericExpression denominator) => new(expressionFormatVisitor, false, numerator, denominator);

        public Division GetDivisionFractionWithParenthesis(NumericExpression numerator, NumericExpression denominator) => new(expressionFormatVisitor, true, numerator, denominator);

        public Division GetDivisionInline(params NumericExpression[] expressions) => new(expressionFormatVisitor, false, expressions);

        public Division GetDivisionInlineWithParenthesis(params NumericExpression[] expressions) => new(expressionFormatVisitor, true, expressions);

        public Equality GetEquality
            (NumericExpression lhs, NumericExpression rhs) => new(lhs, rhs);

        public Equality GetEqualityWithHiddenResult(NumericExpression lhs, NumericExpression rhs) => new(lhs, rhs, true);

        public Multiplication GetMultiplication(params NumericExpression[] expressions) => new(expressionFormatVisitor, expressions);

        public Power GetPower(NumericExpression argumentExpression, NumericExpression powerExpression) => new(expressionFormatVisitor, argumentExpression, powerExpression);

        public Subtraction GetSubtraction(params NumericExpression[] expressions) => new(expressionFormatVisitor, false, expressions);

        public Subtraction GetSubtractionWithParenthesis(params NumericExpression[] expressions) => new(expressionFormatVisitor, true, expressions);

        public Sum GetSum(params NumericExpression[] expressions) => new(expressionFormatVisitor, false, expressions);

        public Sum GetSumWithParenthesis(params NumericExpression[] expressions) => new(expressionFormatVisitor, true, expressions);
    }
}