using Meg.Ui.Expressions;
using System.Text;

namespace Meg.Ui.Presentations.Latex
{
    /// <summary>
    /// https://www.overleaf.com/learn/latex/Mathematical_expressions
    /// </summary>
    public class LatexExpressionFormatVisitor : IExpressionFormatVisitor
    {
        public string Visit(SumExpression expression)
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

        public string Visit(SubtractionExpression expression)
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

        public string Visit(MultiplicationExpression expression)
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

        public string Visit(DivisionExpression expression)
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

        private static string TryWrapExpressionInParenthesis(Expression<double> expression)
                => expression.ToResultFunc().Invoke() < 0 ? $"({expression.ToFormat()})" : expression.ToFormat();

        private static string GetOperationString<TInput, TResult>(OperationExpression<TInput, TResult> expression)
            where TInput : struct
            where TResult : struct
            => expression.OperationType switch
            {
                OperationType.Sum => "+",
                OperationType.Subtraction => "-",
                OperationType.Multiplication => "\\times",
                OperationType.Division => ":",
                OperationType.Equality => "=",
                _ => throw new ArgumentException("Unexpected operation case."),
            };
    }
}
