using Meg.Ui.Expressions;
using Meg.Ui.Problems;

namespace Meg.Ui.Sheets
{
    public class SubtractionProblemSheet : ProblemSheet
    {
        public SubtractionProblemSheet(SumProblemSheetConfiguration configuration)
            => Problems = CreateProblems(configuration).ToList();

        protected override List<Problem> Problems { get; }

        private static IEnumerable<Problem> CreateProblems(SumProblemSheetConfiguration configuration)
        {
            var problems = new List<Problem>();

            for (var i = 0; i < configuration.ProblemCount; i++)
            {
                var members = GetMembers(configuration);

                var lhs = new SubtractionExpression(members.ToArray());
                var rhs = new ConstantExpression(lhs.ToFunc().Invoke());
                var eqExpr = new EqualityExpression(lhs, rhs);

                problems.Add(new Problem(i + 1, eqExpr));
            }

            return problems;
        }

        private static IEnumerable<Expression<double>> GetMembers(SumProblemSheetConfiguration configuration)
        {
            var random = new Random();
            var list = new List<Expression<double>>();

            for (var i = 0; i < configuration.ExpressionMemberCount; i++)
            {
                var number = random.Next(configuration.MinValue, configuration.MaxValue + 1);
                var member = new ConstantExpression(number);

                list.Add(member);
            }

            return list;
        }
    }
}
