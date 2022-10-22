namespace Meg.Core.Expressions.Primitives
{
    public class Constant : NumericExpression
    {
        public Constant(double value, string unknown)
        {
            if (string.IsNullOrWhiteSpace(unknown))
            {
                throw new ArgumentException($"'{nameof(unknown)}' cannot be null or whitespace.", nameof(unknown));
            }

            Value = value;
            Unknown = unknown;
            IsUnknown = true;
        }

        public Constant(double value)
        {
            Value = value;
            Unknown = null;
            IsUnknown = false;
        }

        public bool IsUnknown { get; } = false;

        public string? Unknown { get; }
        public double Value { get; }

        public override double Compute() => Value;

        public override string ToFormat() => IsUnknown ? Unknown! : Value.ToString();
    }
}