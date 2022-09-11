using Meg.Core.Exercises.Sheets;
using Meg.Core.Extensions;
using Meg.Core.Presentations.Latex;

namespace Meg.Ui
{
    internal static class Program
    {
        private static readonly string OutputAnswersPath = @"C:\Users\GeorgeVasilchenko\OneDrive - Source Line\Desktop\answers.png";
        private static readonly string OutputExercisePath = @"C:\Users\GeorgeVasilchenko\OneDrive - Source Line\Desktop\exercise.png";

        private static void Main()
        {
            var sheet1 = new Sheet1(new LatexExpressionFormatVisitor());
            var exercises = sheet1.CreateExercises();

            var latexExercises = LatexDocumentFormatter.ToLatex(exercises.AsArray());
            new LatexFileRenderer(OutputExercisePath).WriteToFile(latexExercises);

            var latexAnswers = LatexDocumentFormatter.ToLatex(exercises.AsArray(), true);
            new LatexFileRenderer(OutputAnswersPath).WriteToFile(latexAnswers);
        }
    }
}
