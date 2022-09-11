using Meg.Core.Exercises.Topics;
using Meg.Core.Presentations;

namespace Meg.Core.Exercises.Sheets
{
    public class Sheet1 : ExercisesSheet
    {
        private readonly Sum2Integers sum2Integers;

        public Sheet1(IExpressionFormatVisitor visitor)
        {
            sum2Integers = new Sum2Integers(visitor, new Sum2IntegersConfig("a", 5, 50));
        }

        public override IEnumerable<Exercise> CreateExercises()
        {
            return sum2Integers.GetExercises(15);
        }
    }
}
