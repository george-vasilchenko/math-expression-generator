namespace Meg.Ui.Expressions
{
    public class ConstantExpression : Expression<double>
    {
        public ConstantExpression(double constant) => Constant = constant;

        public double Constant { get; }

        public override Func<double> ToFunc() => () => Constant;

        public override string ToString() => Constant.ToString();
    }
}
