using Meg.Ui.Problems;
using System.Text;

namespace Meg.Ui.Presentations.Latex
{
    public static class ProblemToLatexParser
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
    }
}
