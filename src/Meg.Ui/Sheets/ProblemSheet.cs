using System.Text;
using Meg.Ui.Problems;

namespace Meg.Ui.Sheets
{
    public abstract class ProblemSheet : IProblemSheet
    {
        protected abstract IEnumerable<Problem> Problems { get; }

        public string GetAnswersSheet()
        {
            var array = Problems.ToArray();
            var builder = new StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                var p = array[i];
                var text = $"{p.Id}. {p.Answer}";

                builder.AppendLine(text);
            }

            return builder.ToString();
        }

        public string GetProblemsSheet()
        {
            var array = Problems.ToArray();
            var builder = new StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                var p = array[i];
                var text = $"{p.Id}. {p.Question} = {p.Answer}";

                builder.AppendLine(text);
            }

            return builder.ToString();
        }

        public string GetQuestionsSheet()
        {
            var array = Problems.ToArray();
            var builder = new StringBuilder();

            for (var i = 0; i < array.Length; i++)
            {
                var p = array[i];
                var text = $"{p.Id}. {p.Question} = ?";

                builder.AppendLine(text);
            }

            return builder.ToString();
        }
    }
}
