namespace Meg.Core.Expressions.Primitives
{
    public class Constant : NumericExpression
    {
        private Constant(double value, string unknown)
        {
            if (string.IsNullOrWhiteSpace(unknown))
            {
                throw new ArgumentException($"'{nameof(unknown)}' cannot be null or whitespace.", nameof(unknown));
            }

            Value = value;
            Unknown = unknown;
            IsUnknown = true;
        }

        private Constant(double value)
        {
            Value = value;
            Unknown = null;
            IsUnknown = false;
        }

        public bool IsUnknown { get; } = false;

        public string? Unknown { get; }
        public double Value { get; }

        public static Constant FromExpression(ComputationExpression<double> expression) => new(expression.Compute());

        public static Constant New(double value) => new(value);

        public static Constant NewAsUnknown(double value, string unknown) => new(value, unknown);

        public override double Compute() => Value;

        public override string ToFormat() => IsUnknown ? Unknown! : Value.ToString();
    }
}
