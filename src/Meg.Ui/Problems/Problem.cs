using Meg.Ui.Expressions;

namespace Meg.Ui.Problems
{
    public class Problem
    {
        public Problem(int id, EqualityExpression expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            Id = id;
            Question = expression.Lhs.ToString();
            Answer = expression.Rhs.ToString();
        }

        public string Answer { get; }

        public int Id { get; }

        public string Question { get; }
    }
}
