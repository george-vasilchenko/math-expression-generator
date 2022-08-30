using Meg.Ui.Expressions;
using Meg.Ui.Problems;

namespace Meg.Ui.Sheets
{
    public class DivisionProblemSheet : ProblemSheet
    {
        public DivisionProblemSheet(DivisionProblemSheetConfiguration configuration)
            => Problems = CreateProblems(configuration).ToList();

        public override List<Problem> Problems { get; }

        private static IEnumerable<Problem> CreateProblems(DivisionProblemSheetConfiguration configuration)
        {
            var problems = new List<Problem>();

            for (var i = 0; i < configuration.ProblemCount; i++)
            {
                var members = GetMembers(configuration);

                var lhs = new DivisionExpression(members.ToArray());
                var rhs = new ConstantExpression(lhs.ToFunc().Invoke());
                var eqExpr = new EqualityExpression(lhs, rhs);

                problems.Add(new Problem(i + 1, eqExpr));
            }

            return problems;
        }

        private static IEnumerable<Expression<double>> GetMembers(DivisionProblemSheetConfiguration configuration)
        {
            var random = new Random();
            var list = new List<double>();
            var numbers = Enumerable.Range(0, configuration.ExpressionMemberCount)
                    .Select(_ => GetRandomNumber(configuration, random)).ToList();
            var result = numbers.Aggregate((a, b) => a * b);

            list.Add(result);

            for (var i = numbers.Count - 1; i > 0; i--)
            {
                list.Add(numbers[i]);
            }

            return list.Select(n => new ConstantExpression(n));
        }

        private static int GetRandomNumber(DivisionProblemSheetConfiguration configuration, Random random)
            => random.Next(configuration.MinValue, configuration.MaxValue + 1);
    }
}
