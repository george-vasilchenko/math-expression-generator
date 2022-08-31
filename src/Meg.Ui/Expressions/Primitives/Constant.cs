namespace Meg.Ui.Expressions.Primitives
{
    public class Constant : Expression<double>
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

        public static Constant FromExpression(Expression<double> expression) => new(expression.ToResultFunc().Invoke());

        public static Constant New(double value) => new(value);

        public static Constant NewAsUnknown(double value, string unknown) => new(value, unknown);

        public override string ToFormat() => IsUnknown ? Unknown! : Value.ToString();

        public override Func<double> ToResultFunc() => () => Value;
    }
}
