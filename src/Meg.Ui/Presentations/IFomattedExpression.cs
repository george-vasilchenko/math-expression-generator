namespace Meg.Ui.Presentations
{
    public interface IFomattedExpression
    {
        string ApplyFormat(IExpressionFormatVisitor formatVisitor);
    }
}
