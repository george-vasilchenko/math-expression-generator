using Meg.Ui.Expressions;
using Meg.Ui.Expressions.Functions;
using System.Text;

namespace Meg.Ui.Presentations.Latex
{
    /// <summary>
    /// https://www.overleaf.com/learn/latex/Mathematical_expressions
    /// </summary>
    public class LatexExpressionFormatVisitor : IExpressionFormatVisitor
    {
        public string Visit<TResult>(ComputationExpression<TResult> expression)
        {
            switch (expression)
            {
                case Sum sum:
                    return HandleSum(sum);

                case Subtraction subtraction:
                    return HandleSubtraction(subtraction);

                case Multiplication multiplication:
                    return HandleMultiplication(multiplication);

                case Division division:
                    return HandleDivision(division);

                case Power power:
                    return HandlePower(power);

                default:
                    throw new InvalidOperationException("Unsupported type was provided");
            }
        }

        private static string GetOperationString<TInput, TResult>(OperationExpression<TInput, TResult> expression)
            => expression.OperationType switch
            {
                OperationType.Sum => "+",
                OperationType.Subtraction => "-",
                OperationType.Multiplication => "\\times",
                OperationType.Division => ":",
                _ => throw new ArgumentException("Unexpected operation case."),
            };

        private static string HandleDivision(Division expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var result = new StringBuilder();

            if (expression.IsFraction)
            {
                var numerator = expression.Expressions[0].ToFormat();
                var denominator = expression.Expressions[1].ToFormat();

                result.Append($"\\frac{{{numerator}}}{{{denominator}}}");
            }
            else
            {
                var array = expression.Expressions.ToArray();
                for (var i = 0; i < array.Length; i++)
                {
                    var exp = array[i];

                    if (i == 0)
                    {
                        result.Append($"{exp.ToFormat()}");
                    }
                    else
                    {
                        result.Append($" {TryWrapExpressionInParenthesis(exp)}");
                    }

                    if (i != array.Length - 1)
                    {
                        result.Append($" {GetOperationString(expression)}");
                    }
                }
            }

            if (expression.HasParenthesis)
            {
                result.Insert(0, "(");
                result.Append(')');
            }

            return result.ToString();
        }

        private static string HandleMultiplication(Multiplication expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var array = expression.Expressions.ToArray();
            var result = new StringBuilder();
            var length = array.Length;

            for (var i = 0; i < length; i++)
            {
                var exp = array[i];

                if (i == 0)
                {
                    result.Append($"{exp.ToFormat()}");
                }
                else
                {
                    result.Append($" {TryWrapExpressionInParenthesis(exp)}");
                }

                if (i != length - 1)
                {
                    result.Append($" {GetOperationString(expression)}");
                }
            }

            return result.ToString();
        }

        private static string HandlePower(Power expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var argumentPart = expression.ArgumentExpression.ToFormat();
            var powerPart = expression.PowerExpression.ToFormat();

            return $"({argumentPart})^{{{powerPart}}}";
        }

        private static string HandleSubtraction(Subtraction expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var array = expression.Expressions.ToArray();
            var result = new StringBuilder();
            var length = array.Length;

            for (var i = 0; i < length; i++)
            {
                var exp = array[i];

                if (i == 0)
                {
                    result.Append($"{exp.ToFormat()}");
                }
                else
                {
                    result.Append($" {TryWrapExpressionInParenthesis(exp)}");
                }

                if (i != length - 1)
                {
                    result.Append($" {GetOperationString(expression)}");
                }
            }

            return result.ToString();
        }

        private static string HandleSum(Sum expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var array = expression.Expressions.ToArray();
            var result = new StringBuilder();
            var length = array.Length;

            for (var i = 0; i < length; i++)
            {
                var exp = array[i];

                if (i == 0)
                {
                    result.Append($"{exp.ToFormat()}");
                }
                else
                {
                    result.Append($" {TryWrapExpressionInParenthesis(exp)}");
                }

                if (i != length - 1)
                {
                    result.Append($" {GetOperationString(expression)}");
                }
            }

            if (expression.HasParenthesis)
            {
                result.Insert(0, "(");
                result.Append(')');
            }

            return result.ToString();
        }

        private static string TryWrapExpressionInParenthesis(ComputationExpression<double> expression)
            => expression.GetComputationFunc().Invoke() < 0 ? $"({expression.ToFormat()})" : expression.ToFormat();
    }
}
