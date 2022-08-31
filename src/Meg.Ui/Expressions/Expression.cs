namespace Meg.Ui.Expressions
{
    public abstract class Expression<TResult>
    {
        public abstract string ToFormat();

        public abstract Func<TResult> ToResultFunc();
    }
}
