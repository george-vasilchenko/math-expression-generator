namespace Meg.Ui.Expressions.Functions
{
    public abstract class FunctionalExpression : NumericExpression
    {
        protected FunctionalExpression(FunctionType functionType, NumericExpression argumentExpression)
        {
            ArgumentExpression = argumentExpression;
            FunctionType = functionType;
        }

        public NumericExpression ArgumentExpression { get; }
        public FunctionType FunctionType { get; }
    }
}
