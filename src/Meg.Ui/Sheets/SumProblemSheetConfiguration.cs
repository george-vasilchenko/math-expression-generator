namespace Meg.Ui.Sheets
{
    public class SumProblemSheetConfiguration : ProblemSheetConfiguration
    {
        public SumProblemSheetConfiguration(int problemCount, int expressionMemberCount, int minValue, int maxValue)
            : base(problemCount, expressionMemberCount)
        {
            if (minValue >= maxValue)
            {
                throw new ArgumentException("Min and max value should be logically different");
            }

            MinValue = minValue;
            MaxValue = maxValue;
        }

        public int MaxValue { get; }

        public int MinValue { get; }
    }
}
