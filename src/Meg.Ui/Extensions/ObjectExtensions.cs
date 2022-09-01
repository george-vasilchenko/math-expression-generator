namespace Meg.Ui.Extensions
{
    public static class ObjectExtensions
    {
        public static T[] AsArray<T>(this T obj)
        {
            return new T[] { obj };
        }

        public static IEnumerable<T> AsEnumerable<T>(this T obj)
        {
            return new T[] { obj };
        }
    }
}
