using Meg.Core.Expressions.Functions;
using Meg.Core.Expressions.Operations;
using Meg.Core.Expressions.Primitives;

namespace Meg.Core.Expressions
{
    public interface IExpressionFactory
    {
        Constant GetConstant(double value);
        Constant GetConstantAsUnknown(double value, string unknown);
        Constant GetConstantFromExpression(ComputationExpression<double> expression);
        Division GetDivisionFraction(NumericExpression numerator, NumericExpression denominator);
        Division GetDivisionFractionWithParenthesis(NumericExpression numerator, NumericExpression denominator);
        Division GetDivisionInline(params NumericExpression[] expressions);
        Division GetDivisionInlineWithParenthesis(params NumericExpression[] expressions);
        Equality GetEquality(NumericExpression lhs, NumericExpression rhs);
        Equality GetEqualityWithHiddenResult(NumericExpression lhs, NumericExpression rhs);
        Multiplication GetMultiplication(params NumericExpression[] expressions);
        Power GetPower(NumericExpression argumentExpression, NumericExpression powerExpression);
        Subtraction GetSubtraction(params NumericExpression[] expressions);
        Subtraction GetSubtractionWithParenthesis(params NumericExpression[] expressions);
        Sum GetSum(params NumericExpression[] expressions);
        Sum GetSumWithParenthesis(params NumericExpression[] expressions);
    }
}