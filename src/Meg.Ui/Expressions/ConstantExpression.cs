namespace Meg.Ui.Expressions
{
    public class ConstantExpression : Expression<double>
    {
        public ConstantExpression(double constant) => Constant = constant;

        public double Constant { get; }

        public override Func<double> ToResultFunc() => () => Constant;

        public override string ToFormat() => Constant.ToString();
    }
}
