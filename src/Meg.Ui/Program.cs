using Meg.Ui.Expressions;
using Meg.Ui.Presentations.Latex;
using Meg.Ui.Problems;
using Meg.Ui.Sheets;
using CE = Meg.Ui.Expressions.ConstantExpression;
using LE = Meg.Ui.Presentations.Latex.LatexExpressionFormatVisitor;

namespace Meg.Ui
{
    internal static class Program
    {
        private static readonly string OutputFilePath = @"C:\Users\GeorgeVasilchenko\OneDrive - Source Line\Desktop\formula.png";

        private static void Main()
        {
            var p = C(new LE());

            Print(p);
        }

        private static void Print(Problem p)
        {
            var latex = ProblemToLatexParser.ToLatex(p);
            var renderer = new LatexFileRenderer(OutputFilePath);
            renderer.WriteToFile(latex);
        }

        private static Problem C(LE le)
        {
            var se1 = new SumExpression(le, true, new CE(1), new CE(123));
            var de = DivisionExpression.NewFraction(le, false, se1, new CE(2));
            var se2 = new SumExpression(le, new CE(-20), de);
            var ex = new EqualityExpression(se2, new CE(se2.ToResultFunc().Invoke()));

            return new Problem(1, ex);
        }

        private static Problem B(LE le)
        {
            var se1 = new SumExpression(le, true, new CE(2), new CE(2));
            var se = new SumExpression(le, new CE(1), se1);
            var ex = new EqualityExpression(se, new CE(se.ToResultFunc().Invoke()));

            return new Problem(1, ex);
        }

        private static IEnumerable<Problem> A()
        {
            var expressionFormatVisitor = new LE();
            var sheetConfiguration = new SumProblemSheetConfiguration(30, 2, 1, 10);
            var sheet = new SumProblemSheet(expressionFormatVisitor, sheetConfiguration);

            return sheet.CreateProblems();
        }
    }
}
