using Meg.Ui.Problems;
using System.Text;

namespace Meg.Ui.Sheets
{
    public static class SheetToLatexParser
    {
        public static string ToLatex(IEnumerable<Problem> problems)
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
