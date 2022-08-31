namespace Meg.Ui.Expressions
{
    public abstract class Expression<TResult>
        where TResult : struct
    {
        public abstract Func<TResult> ToResultFunc();

        public abstract string ToFormat();
    }
}
