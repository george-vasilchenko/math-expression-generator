using Meg.Ui.Expressions;
using Meg.Ui.Expressions.Primitives;
using Meg.Ui.Presentations;
using Meg.Ui.Problems;
using Meg.Ui.Sheets.Common;

namespace Meg.Ui.Sheets
{
    public class DivisionProblemSheet : ProblemSheet
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;
        private readonly DivisionProblemSheetConfiguration configuration;

        public DivisionProblemSheet(IExpressionFormatVisitor expressionFormatVisitor, DivisionProblemSheetConfiguration configuration)
        {
            this.expressionFormatVisitor = expressionFormatVisitor;
            this.configuration = configuration;
        }

        public override IEnumerable<Problem> CreateProblems()
        {
            var problems = new List<Problem>();

            for (var i = 0; i < configuration.ProblemCount; i++)
            {
                var members = GetMembers(configuration);

                var lhs = Division.NewInline(expressionFormatVisitor, members.ToArray());
                var rhs = Constant.New(lhs.ToResultFunc().Invoke());
                var eqExpr = Equality.New(lhs, rhs);

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

            return list.Select(n => Constant.New(n));
        }

        private static int GetRandomNumber(DivisionProblemSheetConfiguration configuration, Random random)
            => random.Next(configuration.MinValue, configuration.MaxValue + 1);
    }
}
