namespace Meg.Ui.Expressions
{
    public class FunctionalExpression : Expression<double>
    {
        public override Func<double> ToFunc() => throw new NotImplementedException();

        public override string ToString() => throw new NotImplementedException();
    }
}
