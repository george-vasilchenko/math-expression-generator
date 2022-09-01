using Meg.Ui.Presentations;

namespace Meg.Ui.Exercises.Sheets
{
    public class Sheet1 : ExercisesSheet
    {
        public Sheet1(IExpressionFormatVisitor visitor) : base(visitor)
        {
        }

        public override IEnumerable<Exercise> CreateExercises()
        {
            var exercises = new List<Exercise>();
            var id = 1;

            for (int i = 1; i <= 5; i++)
            {
                exercises.Add(GetMultWith2Constants(id++));
            }

            for (int i = 1; i <= 5; i++)
            {
                exercises.Add(GetDivWith2Constants(id++));
            }

            for (int i = 1; i <= 5; i++)
            {
                exercises.Add(GetFracWith2Constants(id++));
            }

            for (int i = 1; i <= 3; i++)
            {
                exercises.Add(GetPowerWith2Constants(id++));
            }

            return exercises;
        }
    }
}
