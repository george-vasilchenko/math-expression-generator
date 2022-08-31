using Meg.Ui.Expressions;

namespace Meg.Ui.Problems
{
    public class Problem
    {
        public Problem(int id, Equality expression)
        {
            if (expression is null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            Id = id;
            Question = expression.Lhs.ToFormat();
            Answer = expression.Rhs.ToFormat();
        }

        public string Answer { get; }

        public int Id { get; }

        public string Question { get; }
    }
}
