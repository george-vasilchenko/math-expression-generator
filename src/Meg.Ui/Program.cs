using Meg.Core.Exercises.Sheets;
using Meg.Core.Expressions;
using Meg.Core.Extensions;
using Meg.Core.Presentations.Latex;

namespace Meg.Ui
{
    internal static class Program
    {
        private static readonly string OutputAnswersPath = @"C:\Users\georg\Desktop\Rekensomen\answers.png";
        private static readonly string OutputExercisePath = @"C:\Users\georg\Desktop\Rekensomen\exercise.png";

        private static void Main()
        {
            var latexVisitor = new LatexExpressionFormatVisitor();
            var expressionFactory = new ExpressionFactory(latexVisitor);
            var sheet = new Sheet(expressionFactory);
            var exercises = sheet.CreateExercises();

            var latexExercises = LatexDocumentFormatter.ToLatex(exercises.AsArray());
            new LatexFileRenderer(OutputExercisePath).WriteToFile(latexExercises);

            var latexAnswers = LatexDocumentFormatter.ToLatex(exercises.AsArray(), true);
            new LatexFileRenderer(OutputAnswersPath).WriteToFile(latexAnswers);
        }
    }
}