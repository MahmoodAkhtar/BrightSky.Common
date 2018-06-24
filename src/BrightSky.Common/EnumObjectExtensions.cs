using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BrightSky.Common
{
    internal static class EnumObjectExtensions
    {
        public static Result<T> To<T>(this EnumObjectDefinition<T> extendee) where T : EnumObject<T> => Result.Combine(
            Guard.IfNull(extendee, nameof(extendee)),
            Guard.IfTrue(() =>
                typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(string) }, null) == null,
                $"Unable to find a static constructor."))
            .OnSuccess(() => typeof(T).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(int), typeof(string) }, null))
            .Map((constructor) => (T)constructor.Invoke(new object[] { extendee.Value, extendee.Name }));
    }
}
