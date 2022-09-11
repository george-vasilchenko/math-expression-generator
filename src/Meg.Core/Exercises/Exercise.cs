using Meg.Core.Expressions;
using Meg.Core.Expressions.Primitives;

namespace Meg.Core.Exercises
{
    public class Exercise
    {
        public Exercise(string label, Equality problem, Constant unknown)
        {
            Label = label;
            Problem = problem ?? throw new ArgumentNullException(nameof(problem));
            Unknown = unknown ?? throw new ArgumentNullException(nameof(unknown));
        }

        public string Label { get; }
        public Equality Problem { get; }
        public Constant Unknown { get; }
    }
}
