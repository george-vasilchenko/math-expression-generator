namespace Meg.Core.Presentations
{
    public interface IFomattedExpression
    {
        string ApplyFormat(IExpressionFormatVisitor formatVisitor);
    }
}
