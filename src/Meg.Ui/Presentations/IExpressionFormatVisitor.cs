using Meg.Ui.Expressions;

namespace Meg.Ui.Presentations
{
    public interface IExpressionFormatVisitor
    {
        string Visit<TResult>(Expression<TResult> expression);
    }
}
