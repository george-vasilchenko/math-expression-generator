using Meg.Ui.Problems;

namespace Meg.Ui.Sheets.Common
{
    public interface IProblemSheet
    {
        IEnumerable<Problem> CreateProblems();
    }
}
