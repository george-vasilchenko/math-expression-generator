using Meg.Ui.Presentations.Latex;
using Meg.Ui.Sheets;

namespace Meg.Ui
{
    internal static class Program
    {
        private static readonly string OutputFilePath = @"C:\Users\GeorgeVasilchenko\OneDrive - Source Line\Desktop\formula.png";

        private static void Main()
        {
            var expressionFormatVisitor = new LatexExpressionFormatVisitor();
            var sheetConfiguration = new SumProblemSheetConfiguration(30, 2, 1, 10);
            var sheet = new SumProblemSheet(expressionFormatVisitor, sheetConfiguration);
            var problems = sheet.CreateProblems();
            var latex = SheetToLatexParser.ToLatex(problems);

            var renderer = new LatexFileRenderer(OutputFilePath);
            renderer.WriteToFile(latex);
        }
    }
}
