using System;

namespace BrightSky.Common
{
    public static class ResultExtensions
    {
        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            if (!predicate(result.Value))
                return Result.Fail<T>(errorMessage);

            return Result.Ok(result.Value);
        }

        public static Result Ensure(this Result result, Func<bool> predicate, string errorMessage)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            if (!predicate())
                return Result.Fail(errorMessage);

            return Result.Ok();
        }

        public static Result<K> Map<T, K>(this Result<T> result, Func<T, K> function)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return Result.Ok(function(result.Value));
        }

        public static Result<T> Map<T>(this Result result, Func<T> function)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return Result.Ok(function());
        }

        public static T OnBoth<T>(this Result result, Func<Result, T> function)
        {
            return function(result);
        }

        public static K OnBoth<T, K>(this Result<T> result, Func<Result<T>, K> function)
        {
            return function(result);
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        public static Result OnFailure(this Result result, Action action)
        {
            if (result.IsFailure)
            {
                action();
            }

            return result;
        }

        public static Result<T> OnFailure<T>(this Result<T> result, Action<string> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        public static Result OnFailure(this Result result, Action<string> action)
        {
            if (result.IsFailure)
            {
                action(result.Error);
            }

            return result;
        }

        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<T, K> function)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return Result.Ok(function(result.Value));
        }

        public static Result<T> OnSuccess<T>(this Result result, Func<T> function)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return Result.Ok(function());
        }

        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<T, Result<K>> function)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return function(result.Value);
        }

        public static Result<T> OnSuccess<T>(this Result result, Func<Result<T>> function)
        {
            if (result.IsFailure)
                return Result.Fail<T>(result.Error);

            return function();
        }

        public static Result<K> OnSuccess<T, K>(this Result<T> result, Func<Result<K>> function)
        {
            if (result.IsFailure)
                return Result.Fail<K>(result.Error);

            return function();
        }

        public static Result OnSuccess<T>(this Result<T> result, Func<T, Result> function)
        {
            if (result.IsFailure)
                return Result.Fail(result.Error);

            return function(result.Value);
        }

        public static Result OnSuccess(this Result result, Func<Result> function)
        {
            if (result.IsFailure)
                return result;

            return function();
        }

        public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess)
            {
                action(result.Value);
            }

            return result;
        }

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsSuccess)
            {
                action();
            }

            return result;
        }
    }
}