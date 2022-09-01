namespace Meg.Ui.Extensions
{
    public static class EnumerableExtensions
    {
        public static T[] AsArray<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable is null)
            {
                throw new ArgumentNullException(nameof(enumerable));
            }

            return enumerable.ToArray();
        }
    }
}
