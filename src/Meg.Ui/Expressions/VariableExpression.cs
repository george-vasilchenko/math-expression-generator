namespace Meg.Ui.Expressions
{
    public class VariableExpression : Expression<double>
    {
        public override Func<double> ToFunc() => throw new NotImplementedException();

        public override string ToString() => throw new NotImplementedException();
    }
}
