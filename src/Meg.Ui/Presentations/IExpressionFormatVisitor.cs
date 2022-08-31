using Meg.Ui.Expressions;

namespace Meg.Ui.Presentations
{
    public interface IExpressionFormatVisitor
    {
        string Visit(SumExpression expression);

        string Visit(SubtractionExpression expression);

        string Visit(MultiplicationExpression expression);

        string Visit(DivisionExpression expression);
    }
}
