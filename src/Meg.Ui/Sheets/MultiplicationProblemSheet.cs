using Meg.Ui.Expressions;
using Meg.Ui.Expressions.Primitives;
using Meg.Ui.Presentations;
using Meg.Ui.Problems;
using Meg.Ui.Sheets.Common;

namespace Meg.Ui.Sheets
{
    public class MultiplicationProblemSheet : ProblemSheet
    {
        private readonly IExpressionFormatVisitor expressionFormatVisitor;
        private readonly MultiplicationProblemSheetConfiguration configuration;

        public MultiplicationProblemSheet(IExpressionFormatVisitor expressionFormatVisitor, MultiplicationProblemSheetConfiguration configuration)
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

                var lhs = new Multiplication(expressionFormatVisitor, members.ToArray());
                var rhs = Constant.New(lhs.ToResultFunc().Invoke());
                var eqExpr = Equality.New(lhs, rhs);

                problems.Add(new Problem(i + 1, eqExpr));
            }

            return problems;
        }

        private static IEnumerable<Expression<double>> GetMembers(MultiplicationProblemSheetConfiguration configuration)
        {
            var random = new Random();
            var list = new List<Expression<double>>();

            for (var i = 0; i < configuration.ExpressionMemberCount; i++)
            {
                var number = random.Next(configuration.MinValue, configuration.MaxValue + 1);
                var member = Constant.New(number);

                list.Add(member);
            }

            return list;
        }
    }
}
