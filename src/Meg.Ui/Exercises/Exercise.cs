using Meg.Ui.Expressions;
using Meg.Ui.Expressions.Primitives;

namespace Meg.Ui.Exercises
{
    public class Exercise
    {
        public Exercise(int number, Equality problem, Constant unknown)
        {
            Number = number;
            Problem = problem ?? throw new ArgumentNullException(nameof(problem));
            Unknown = unknown ?? throw new ArgumentNullException(nameof(unknown));
        }

        public int Number { get; }
        public Equality Problem { get; }
        public Constant Unknown { get; }
    }
}
