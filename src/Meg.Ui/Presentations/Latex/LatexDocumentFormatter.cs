﻿using Meg.Ui.Expressions;
using System.Text;
using Exercise = Meg.Ui.Exercises.Exercise;

namespace Meg.Ui.Presentations.Latex
{
    public static class LatexDocumentFormatter
    {
        public static string ToLatex(params Expression[] expressions)
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

        public static string ToLatex(IEnumerable<Exercise> exercises, bool renderAsAnswer = false)
        {
            if (exercises is null)
            {
                throw new ArgumentNullException(nameof(exercises));
            }

            var builder = new StringBuilder();

            foreach (var ex in exercises)
            {
                var content = renderAsAnswer
                    ? $"{ex.Unknown.ToFormat()} = {ex.Unknown.Compute()}"
                    : $"{ex.Problem.ToFormat()}";
                var segment = $"{ex.Number})\\; {content} \\\\";
                builder.Append(segment);
            }

            return builder.ToString();
        }
    }
}
