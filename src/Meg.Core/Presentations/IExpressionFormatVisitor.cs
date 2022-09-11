using Meg.Core.Expressions;

namespace Meg.Core.Presentations
{
    public interface IExpressionFormatVisitor
    {
        string Visit<TResult>(ComputationExpression<TResult> expression);
    }
}
