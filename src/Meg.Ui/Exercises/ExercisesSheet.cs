using Meg.Ui.Constants;
using Meg.Ui.Expressions;
using Meg.Ui.Expressions.Functions;
using Meg.Ui.Expressions.Primitives;
using Meg.Ui.Extensions;
using Meg.Ui.Presentations;

namespace Meg.Ui.Exercises
{
    public abstract class ExercisesSheet
    {
        private readonly IExpressionFormatVisitor visitor;

        protected ExercisesSheet(IExpressionFormatVisitor visitor)
        {
            this.visitor = visitor;
        }

        public abstract IEnumerable<Exercise> CreateExercises();

        /// <summary>
        /// a / b = x
        /// </summary>
        protected Exercise GetDivWith2Constants(int id)
        {
            var list = new List<double>();
            var numbers = Enumerable.Range(0, 2).Select(_ => GetRandomNumber(1, 10)).ToList();
            var computedResult = numbers.Aggregate((a, b) => a * b);

            list.Add(computedResult);

            for (var i = numbers.Count - 1; i > 0; i--)
            {
                list.Add(numbers[i]);
            }

            var constants = list.Select(n => Constant.New(n)).AsArray();

            var sum = Division.NewInline(visitor, constants);
            var res = Constant.NewAsUnknown(sum.Compute(), GetRandomUnknown());
            var eq = Equality.New(sum, res);

            return new Exercise(id, eq, res);
        }

        /// <summary>
        /// a / b = x (frac)
        /// </summary>
        protected Exercise GetFracWith2Constants(int id)
        {
            static double NumberGen() => GetRandomNumber(2, 11);
            var denom = Constant.New(NumberGen());
            var num = Constant.New(denom.Compute() * NumberGen());

            var div = Division.NewFraction(visitor, num, denom);
            var res = Constant.NewAsUnknown(div.Compute(), GetRandomUnknown());
            var eq = Equality.New(div, res);

            return new Exercise(id, eq, res);
        }

        /// <summary>
        /// a * b = x
        /// </summary>
        protected Exercise GetMultWith2Constants(int id)
        {
            static double NumberGen() => GetRandomNumber(2, 11);
            var sum = Multiplication.New(visitor, Constant.New(NumberGen()), Constant.New(NumberGen()));
            var res = Constant.NewAsUnknown(sum.Compute(), GetRandomUnknown());
            var eq = Equality.New(sum, res);

            return new Exercise(id, eq, res);
        }

        /// <summary>
        /// a ^ b = x
        /// </summary>
        protected Exercise GetPowerWith2Constants(int id)
        {
            var pow = Power.New(visitor, Constant.New(GetRandomNumber(1, 10)), Constant.New(GetRandomNumber(2, 3)));
            var res = Constant.NewAsUnknown(pow.Compute(), GetRandomUnknown());
            var eq = Equality.New(pow, res);

            return new Exercise(id, eq, res);
        }

        /// <summary>
        /// a + b = x
        /// </summary>
        protected Exercise GetSumWith2Constants(int id)
        {
            static double NumberGen() => GetRandomNumber(2, 20);
            var sum = Sum.New(visitor, Constant.New(NumberGen()), Constant.New(NumberGen()));
            var res = Constant.NewAsUnknown(sum.Compute(), GetRandomUnknown());
            var eq = Equality.New(sum, res);

            return new Exercise(id, eq, res);
        }

        /// <summary>
        /// a + b + c = x
        /// </summary>
        protected Exercise GetSumWith3Constants(int id)
        {
            static double NumberGen() => GetRandomNumber(2, 20);
            var sum = Sum.New(visitor, Constant.New(NumberGen()), Constant.New(NumberGen()), Constant.New(NumberGen()));
            var res = Constant.NewAsUnknown(sum.Compute(), GetRandomUnknown());
            var eq = Equality.New(sum, res);

            return new Exercise(id, eq, res);
        }

        private static double GetRandomNumber(int min, int max)
        {
            var random = new Random();
            return random.Next(min, max);
        }

        private static string GetRandomUnknown()
        {
            var unknowns = Unknowns.All;
            var random = new Random();
            return unknowns[random.Next(0, unknowns.Length)];
        }
    }
}
