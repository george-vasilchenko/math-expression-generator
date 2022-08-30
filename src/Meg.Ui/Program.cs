using Meg.Ui.Presentations;
using Meg.Ui.Sheets;

namespace Meg.Ui
{
    internal static class Program
    {
        private static readonly string OutputFilePath = @"C:\Users\GeorgeVasilchenko\OneDrive - Source Line\Desktop\formula.png";

        private static void Main(string[] args)
        {
            var sheet = new DivisionProblemSheet(new DivisionProblemSheetConfiguration(30, 2, 1, 10));
            var sheet2 = new MultiplicationProblemSheet(new MultiplicationProblemSheetConfiguration(20, 3, 1, 10));
            var parsedSheet = SheetToLatexParser.ToLatex(sheet2.Problems);
            var renderer = new LatexFileRenderer(OutputFilePath);
            renderer.WriteToFile(parsedSheet);
        }
    }
}
