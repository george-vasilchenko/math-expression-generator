using Meg.Core.Constants;
using Meg.Core.Expressions;
using Meg.Core.Extensions;

namespace Meg.Core.Exercises
{
    public abstract class ExerciseFactory
    {
        private readonly IExpressionFactory factory;

        protected ExerciseFactory(IExpressionFactory factory) => this.factory = factory;

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

                var constants = list.Select(n => factory.GetConstant(n)).AsArray();

                var sum = factory.GetDivisionInline(constants);
                var res = factory.GetConstantAsUnknown(sum.Compute(), Unknowns.Dots);
                var eq = factory.GetEquality(sum, res);

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
                var denom = factory.GetConstant(NumberGen());
                var num = factory.GetConstant(denom.Compute() * NumberGen());

                var div = factory.GetDivisionFraction(num, denom);
                var res = factory.GetConstantAsUnknown(div.Compute(), Unknowns.Dots);
                var eq = factory.GetEquality(div, res);

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
                var sum = factory.GetMultiplication(factory.GetConstant(NumberGen()), factory.GetConstant(NumberGen()));
                var res = factory.GetConstantAsUnknown(sum.Compute(), Unknowns.Dots);
                var eq = factory.GetEquality(sum, res);

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
                var pow = factory.GetPower(factory.GetConstant(GetRandomNumber(1, 10)), factory.GetConstant(GetRandomNumber(2, 3)));
                var res = factory.GetConstantAsUnknown(pow.Compute(), Unknowns.Dots);
                var eq = factory.GetEquality(pow, res);

                return new Exercise(GetLabel(label, id), eq, res);
            }

            return Enumerable.Range(0, problemCount)
                .Select(i => GetExercise(i))
                .ToList();
        }

        /// <summary>
        /// a / b + c = x
        /// </summary>
        protected IEnumerable<Exercise> GetSumOfDivWith2ConstAndNumber(string label, int problemCount)
        {
            Exercise GetExercise(int id)
            {
                var list = new List<double>();
                var numbers = Enumerable.Range(0, 2).Select(_ => GetRandomNumber(2, 10)).ToList();
                var computedResult = numbers.Aggregate((a, b) => a * b);
                var c = factory.GetConstant(GetRandomNumber(10, 50));

                list.Add(computedResult);

                for (var i = numbers.Count - 1; i > 0; i--)
                {
                    list.Add(numbers[i]);
                }

                var constants = list.Select(n => factory.GetConstant(n)).AsArray();

                var div = factory.GetDivisionInline(constants);
                var sum = factory.GetSum(div, c);
                var res = factory.GetConstantAsUnknown(sum.Compute(), Unknowns.Dots);
                var eq = factory.GetEquality(sum, res);

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
                var sum = factory.GetSum(factory.GetConstant(NumberGen()), factory.GetConstant(NumberGen()));
                var res = factory.GetConstantAsUnknown(sum.Compute(), Unknowns.Dots);
                var eq = factory.GetEquality(sum, res);

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
                var sum = factory.GetSum(factory.GetConstant(NumberGen()), factory.GetConstant(NumberGen()), factory.GetConstant(NumberGen()));
                var res = factory.GetConstantAsUnknown(sum.Compute(), Unknowns.Dots);
                var eq = factory.GetEquality(sum, res);

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
                var a = factory.GetConstant(NumberGen());
                var b = factory.GetConstant(NumberGen());
                var c = factory.GetConstant(NumberGen());

                while (a.Compute() + b.Compute() < c.Compute())
                {
                    var currentValue = a.Value;
                    var newValue = a.Value + 1;

                    a = factory.GetConstant(newValue);
                }

                var sum_ab = factory.GetSum(a, b);
                var sub_ab_c = factory.GetSubtraction(sum_ab, c);
                var res = factory.GetConstantAsUnknown(sub_ab_c.Compute(), Unknowns.Dots);
                var eq = factory.GetEquality(sub_ab_c, res);

                return new Exercise(GetLabel(label, id), eq, res);
            }

            return Enumerable.Range(0, problemCount)
                .Select(i => GetExercise(i))
                .ToList();
        }

        /// <summary>
        /// a + b - c + d = x
        /// </summary>
        protected IEnumerable<Exercise> GetSumWith4ConstantsMixedSignes(string label, int problemCount)
        {
            double NumberGen() => GetRandomNumber(3, 20);

            Exercise GetExercise(int id)
            {
                var a = factory.GetConstant(NumberGen());
                var b = factory.GetConstant(NumberGen());
                var c = factory.GetConstant(NumberGen());
                var d = factory.GetConstant(NumberGen());

                while (a.Compute() + b.Compute() < c.Compute())
                {
                    var currentValue = a.Value;
                    var newValue = a.Value + 1;

                    a = factory.GetConstant(newValue);
                }

                var sum_ab = factory.GetSum(a, b);
                var sub_ab_c = factory.GetSubtraction(sum_ab, c);
                var sum_abc_d = factory.GetSum(sub_ab_c, d);
                var res = factory.GetConstantAsUnknown(sum_abc_d.Compute(), Unknowns.Dots);
                var eq = factory.GetEquality(sum_abc_d, res);

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