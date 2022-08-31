using Meg.Ui.Problems;

namespace Meg.Ui.Sheets.Common
{
    public abstract class ProblemSheet : IProblemSheet
    {
        public abstract IEnumerable<Problem> CreateProblems();
    }
}
