using System.Collections.Generic;
using System.Linq;

namespace BrightSky.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string AsString<T>(this IEnumerable<T> items, string separator = ", ")
        {
            if (items == null || !items.Any()) return string.Empty;

            return string.Join(separator, items);
        }

        public static (T, IReadOnlyList<T>) HeadTail<T>(this IEnumerable<T> items)
        {
            if (items == null || !items.Any()) return (default(T), new T[] { });
            var list = items.ToList();

            return (list.FirstOrDefault(), list.Skip(1).ToList().AsReadOnly());
        }

        public static (IReadOnlyList<T>, T) LeadingLast<T>(this IEnumerable<T> items)
        {
            if (items == null || !items.Any()) return (new T[] { }, default(T));
            var list = items.ToList();
            list.RemoveAt(list.Count());

            return (list.AsReadOnly(), list.LastOrDefault());
        }
    }
}