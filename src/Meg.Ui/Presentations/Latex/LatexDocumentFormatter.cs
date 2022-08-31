using Meg.Ui.Expressions;
using Meg.Ui.Problems;
using System.Text;

namespace Meg.Ui.Presentations.Latex
{
    public static class LatexDocumentFormatter
    {
        public static string ToLatex(params Problem[] problems)
        {
            if (problems is null)
            {
                throw new ArgumentNullException(nameof(problems));
            }

            var builder = new StringBuilder();

            foreach (var p in problems)
            {
                var line = $"{p.Question} = ... \\\\";
                builder.Append(line);
            }

            return builder.ToString();
        }

        public static string ToLatex<TResult>(params Expression<TResult>[] expressions)
        {
            if (expressions is null)
            {
                throw new ArgumentNullException(nameof(expressions));
            }

            var builder = new StringBuilder();

            foreach (var expression in expressions)
            {
                var line = $"{expression.ToFormat()} \\\\";
                builder.Append(line);
            }

            return builder.ToString();
        }
    }
}
