namespace Meg.Ui.Expressions
{
    public class VariableExpression : Expression<double>
    {
        public override Func<double> ToResultFunc() => throw new NotImplementedException();

        public override string ToFormat() => throw new NotImplementedException();
    }
}
