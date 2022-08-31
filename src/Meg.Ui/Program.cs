using Meg.Ui.Expressions;
using Meg.Ui.Expressions.Primitives;
using Meg.Ui.Presentations.Latex;
using Meg.Ui.Problems;
using Meg.Ui.Sheets;

namespace Meg.Ui
{
    internal static class Program
    {
        private static readonly string OutputFilePath = @"C:\Users\GeorgeVasilchenko\OneDrive - Source Line\Desktop\formula.png";

        private static Problem GetCombinedSum(LatexExpressionFormatVisitor le)
        {
            var se1 = Sum.NewWithParenthesis(le, Constant.New(2), Constant.New(2));
            var se = Sum.New(le, Constant.New(1), se1);
            var ex = Equality.New(se, Constant.New(se.ToResultFunc().Invoke()));

            return new Problem(1, ex);
        }

        private static Problem GetFraction(LatexExpressionFormatVisitor le)
        {
            var se1 = Sum.NewWithParenthesis(le, Constant.New(1), Constant.New(123));
            var de = Division.NewFraction(le, se1, Constant.New(2));
            var se2 = Sum.New(le, Constant.New(-20), de);
            var ex = Equality.New(se2, Constant.New(se2.ToResultFunc().Invoke()));

            return new Problem(1, ex);
        }

        private static IEnumerable<Problem> GetSheet()
        {
            var expressionFormatVisitor = new LatexExpressionFormatVisitor();
            var sheetConfiguration = new SumProblemSheetConfiguration(30, 2, 1, 10);
            var sheet = new SumProblemSheet(expressionFormatVisitor, sheetConfiguration);

            return sheet.CreateProblems();
        }

        private static IEnumerable<Problem> GetVariables()
        {
            return null!;
        }

        private static void Main()
        {
            var le = new LatexExpressionFormatVisitor();
            var num1 = Constant.New(10);
            var frac = Division.NewFraction(le, Subtraction.New(le, Constant.New(23), Constant.New(5)), Constant.New(3));
            var num3 = Constant.NewAsUnknown(2, "x");
            var sum = Sum.New(le, num1, frac, num3);
            var eq = Equality.New(sum, Constant.FromExpression(sum));

            Print(eq);
        }

        private static void Print<T>(params Expression<T>[] expressions)
        {
            var latex = LatexDocumentFormatter.ToLatex(expressions);
            var renderer = new LatexFileRenderer(OutputFilePath);
            renderer.WriteToFile(latex);
        }
    }
}
