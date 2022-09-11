using Meg.Core.Constants;
using Meg.Core.Expressions;
using Meg.Core.Expressions.Operations;
using Meg.Core.Expressions.Primitives;
using Meg.Core.Presentations;

namespace Meg.Core.Exercises.Topics
{
    public class Sum2Integers : ExerciseTopic
    {
        private readonly IExpressionFormatVisitor visitor;

        public Sum2Integers(IExpressionFormatVisitor visitor, Sum2IntegersConfig config) : base(config)
        {
            this.visitor = visitor;
        }

        public override IEnumerable<Exercise> GetExercises(byte count)
        {
            var maxCount = Config.GetExerciseCountLimit();

            if (maxCount < count)
            {
                throw new ArgumentException("Requested exercise count exceeds the possible count for given topic");
            }

            var exercises = new List<Exercise>();
            var allSums = new List<Tuple<double, double>>();
            var minValue = (int)Config.MinValue;
            var maxValue = (int)Config.MaxValue;

            for (int a = minValue; a <= maxValue; a++)
            {
                for (int b = minValue; b <= maxValue; b++)
                {
                    allSums.Add(Tuple.Create<double, double>(a, b));
                }
            }

            var random = new Random();
            var resultSums = allSums.OrderBy(o => random.Next()).Take(count).ToList();

            for (int i = 0; i < count; i++)
            {
                var (a, b) = resultSums[i];
                var sum = Sum.New(visitor, Constant.New(a), Constant.New(b));
                var res = Constant.NewAsUnknown(sum.Compute(), Unknowns.Dots);
                var eq = Equality.New(sum, res);
                var label = GetLabel(Config.Label, i);

                exercises.Add(new Exercise(label, eq, res));
            }

            return exercises;
        }

        private static string GetLabel(string label, int id) => $"{label}.{id}";
    }
}
