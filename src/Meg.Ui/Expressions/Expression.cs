namespace Meg.Ui.Expressions
{
    public abstract class Expression<TResult>
        where TResult : struct
    {
        public abstract Func<TResult> ToFunc();

        public new abstract string ToString();
    }
}
