using Meg.Core.Constants;
using Meg.Core.Expressions;
using Meg.Core.Expressions.Functions;
using Meg.Core.Expressions.Operations;
using Meg.Core.Expressions.Primitives;
using Meg.Core.Extensions;
using Meg.Core.Presentations;

namespace Meg.Core.Exercises
{
    public abstract class ExercisesExamples
    {
        private readonly IExpressionFormatVisitor visitor;

        protected ExercisesExamples(IExpressionFormatVisitor visitor)
        {
            this.visitor = visitor;
        }

        public abstract IEnumerable<Exercise> CreateExercises();

        /// <summary>
        /// a / b = x
        /// </summary>
        protected IEnumerable<Exercise> GetDivWith2Constants(string label, int problemCount)
        {
            Exercise GetExercise(int id)
            {
                var list = new List<double>();
                var numbers = Enumerable.Range(0, 2).Select(_ => GetRandomNumber(2, 10)).ToList();
                var computedResult = numbers.Aggregate((a, b) => a * b);

                list.Add(computedResult);

                for (var i = numbers.Count - 1; i > 0; i--)
                {
                    list.Add(numbers[i]);
                }

                var constants = list.Select(n => Constant.New(n)).AsArray();

                var sum = Division.NewInline(visitor, constants);
                var res = Constant.NewAsUnknown(sum.Compute(), Unknowns.Dots);
                var eq = Equality.New(sum, res);

                return new Exercise(GetLabel(label, id), eq, res);
            }

            return Enumerable.Range(0, problemCount)
                .Select(i => GetExercise(i))
                .ToList();
        }

        /// <summary>
        /// a / b = x (frac)
        /// </summary>
        protected IEnumerable<Exercise> GetFracWith2Constants(string label, int problemCount)
        {
            static double NumberGen() => GetRandomNumber(2, 10);

            Exercise GetExercise(int id)
            {
                var denom = Constant.New(NumberGen());
                var num = Constant.New(denom.Compute() * NumberGen());

                var div = Division.NewFraction(visitor, num, denom);
                var res = Constant.NewAsUnknown(div.Compute(), Unknowns.Dots);
                var eq = Equality.New(div, res);

                return new Exercise(GetLabel(label, id), eq, res);
            }

            return Enumerable.Range(0, problemCount)
                .Select(i => GetExercise(i))
                .ToList();
        }

        /// <summary>
        /// a * b = x
        /// </summary>
        protected IEnumerable<Exercise> GetMultWith2Constants(string label, int problemCount)
        {
            static double NumberGen() => GetRandomNumber(2, 10);

            Exercise GetExercise(int id)
            {
                var sum = Multiplication.New(visitor, Constant.New(NumberGen()), Constant.New(NumberGen()));
                var res = Constant.NewAsUnknown(sum.Compute(), Unknowns.Dots);
                var eq = Equality.New(sum, res);

                return new Exercise(GetLabel(label, id), eq, res);
            }

            return Enumerable.Range(0, problemCount)
                .Select(i => GetExercise(i))
                .ToList();
        }

        /// <summary>
        /// a ^ b = x
        /// </summary>
        protected IEnumerable<Exercise> GetPowerWith2Constants(string label, int problemCount)
        {
            Exercise GetExercise(int id)
            {
                var pow = Power.New(visitor, Constant.New(GetRandomNumber(1, 10)), Constant.New(GetRandomNumber(2, 3)));
                var res = Constant.NewAsUnknown(pow.Compute(), Unknowns.Dots);
                var eq = Equality.New(pow, res);

                return new Exercise(GetLabel(label, id), eq, res);
            }

            return Enumerable.Range(0, problemCount)
                .Select(i => GetExercise(i))
                .ToList();
        }

        /// <summary>
        /// a + b = x
        /// </summary>
        protected IEnumerable<Exercise> GetSumWith2Constants(string label, int problemCount)
        {
            static double NumberGen() => GetRandomNumber(2, 20);

            Exercise GetExercise(int id)
            {
                var sum = Sum.New(visitor, Constant.New(NumberGen()), Constant.New(NumberGen()));
                var res = Constant.NewAsUnknown(sum.Compute(), Unknowns.Dots);
                var eq = Equality.New(sum, res);

                return new Exercise(GetLabel(label, id), eq, res);
            }

            return Enumerable.Range(0, problemCount)
                .Select(i => GetExercise(i))
                .ToList();
        }

        /// <summary>
        /// a + b + c = x
        /// </summary>
        protected IEnumerable<Exercise> GetSumWith3Constants(string label, int problemCount)
        {
            static double NumberGen() => GetRandomNumber(2, 20);

            Exercise GetExercise(int id)
            {
                var sum = Sum.New(visitor, Constant.New(NumberGen()), Constant.New(NumberGen()), Constant.New(NumberGen()));
                var res = Constant.NewAsUnknown(sum.Compute(), Unknowns.Dots);
                var eq = Equality.New(sum, res);

                return new Exercise(GetLabel(label, id), eq, res);
            }

            return Enumerable.Range(0, problemCount)
                .Select(i => GetExercise(i))
                .ToList();
        }

        /// <summary>
        /// a + b - c = x
        /// </summary>
        protected IEnumerable<Exercise> GetSumWith3ConstantsMixedSignes(string label, int problemCount)
        {
            double NumberGen() => GetRandomNumber(3, 20);

            Exercise GetExercise(int id)
            {
                var a = Constant.New(NumberGen());
                var b = Constant.New(NumberGen());
                var c = Constant.New(NumberGen());

                while (a.Compute() + b.Compute() < c.Compute())
                {
                    var currentValue = a.Value;
                    var newValue = a.Value + 1;

                    a = Constant.New(newValue);
                }

                var sum_ab = Sum.New(visitor, a, b);
                var sub_ab_c = Subtraction.New(visitor, sum_ab, c);
                var res = Constant.NewAsUnknown(sub_ab_c.Compute(), Unknowns.Dots);
                var eq = Equality.New(sub_ab_c, res);

                return new Exercise(GetLabel(label, id), eq, res);
            }

            return Enumerable.Range(0, problemCount)
                .Select(i => GetExercise(i))
                .ToList();
        }

        private static string GetLabel(string label, int id) => $"{label}.{id}";

        private static double GetRandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }
    }
}
