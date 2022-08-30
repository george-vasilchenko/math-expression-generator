using System.Text;

namespace Meg.Ui.Helpers
{
    public static class OperationExpressionHelpers
    {
        public static string ExpressionsAsDoublesToString(IEnumerable<Expressions.Expression<double>> expressions, string operationString)
        {
            string GetExpBasedOnSign(Expressions.Expression<double> exp) => exp.ToFunc().Invoke() < 0 ? $"({exp.ToString()})" : exp.ToString();

            var array = expressions.ToArray();
            var result = new StringBuilder();
            var length = array.Length;
            for (var i = 0; i < length; i++)
            {
                var exp = array[i];

                if (i == 0)
                {
                    result.Append($"{exp.ToString()}");
                }
                else
                {
                    result.Append($" {GetExpBasedOnSign(exp)}");
                }

                if (i != length - 1)
                {
                    result.Append($" {operationString}");
                }
            }

            return result.ToString();
        }
    }
}
