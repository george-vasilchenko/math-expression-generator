using Meg.Core.Expressions;

namespace Meg.Core.Exercises.Sheets
{
    public class Sheet : ExerciseFactory
    {
        public Sheet(IExpressionFactory factory) : base(factory)
        {
        }

        public override IEnumerable<Exercise> CreateExercises()
        {
            var results = new List<Exercise>();

            results.AddRange(GetSumWith3ConstantsMixedSignes("a", 5));
            results.AddRange(GetSumWith4ConstantsMixedSignes("b", 5));
            results.AddRange(GetMultWith2Constants("c", 5));
            results.AddRange(GetDivWith2Constants("d", 20));
            results.AddRange(GetSumOfDivWith2ConstAndNumber("e", 10));

            return results;
        }
    }
}