using System;

namespace BrightSky.Common.Extensions
{
    public static class FunctionalExtensions
    {
        public static TOutput Map<TInput, TOutput>(this TInput extendee, Func<TInput, TOutput> function)
        {
            return function(extendee);
        }

        public static IResult<TOutput> Pipe<TInput, TOutput>(this IResult<TInput> extendee, Func<IResult<TInput>, IResult<TOutput>> function)
        {
            if (extendee.IsFailure) return Result.Fail<TOutput>(extendee.Error);
            return function(extendee);
        }

        public static T Tee<T>(this T extendee, Action<T> action)
        {
            action(extendee);
            return extendee;
        }
    }
}