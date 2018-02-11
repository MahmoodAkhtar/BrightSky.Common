using System;

namespace BrightSky.Common
{
    public static class FunctionalExtensions
    {
        public static TResult Map<TSource, TResult>(this TSource extendee, Func<TSource, TResult> function)
        {
            return function(extendee);
        }

        public static T Tee<T>(this T extendee, Action<T> action)
        {
            action(extendee);
            return extendee;
        }
    }
}