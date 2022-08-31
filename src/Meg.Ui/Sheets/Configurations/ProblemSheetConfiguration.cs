namespace Meg.Ui.Sheets
{
    public class ProblemSheetConfiguration
    {
        public ProblemSheetConfiguration(int problemCount, int expressionMemberCount)
        {
            if (problemCount < 1)
            {
                throw new ArgumentException("Problem count has to be at least 1");
            }

            if (expressionMemberCount < 2)
            {
                throw new ArgumentException("Expression member count has to be at least 2");
            }

            ProblemCount = problemCount;
            ExpressionMemberCount = expressionMemberCount;
        }

        public int ExpressionMemberCount { get; }
        public int ProblemCount { get; }
    }
}
