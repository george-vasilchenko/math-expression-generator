using Meg.Core.Presentations;

namespace Meg.Core.Expressions.Functions
{
    public class Power : FunctionalExpression
    {
        private readonly IExpressionFormatVisitor visitor;

        public Power(IExpressionFormatVisitor visitor, NumericExpression argumentExpression, NumericExpression powerExpression)
            : base(FunctionType.Power, argumentExpression)
        {
            this.visitor = visitor;
            PowerExpression = powerExpression;
        }

        public NumericExpression PowerExpression { get; }

        public override double Compute()
        {
            var argument = ArgumentExpression.Compute();
            var power = PowerExpression.Compute();
            return Math.Pow(argument, power);
        }

        public override string ToFormat() => visitor.Visit(this);
    }
}