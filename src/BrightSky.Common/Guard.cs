using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrightSky.Common
{
    public static class Guard
    {
        public static Result IfNull<T>(T argument, string name)
        {
            if (argument == null) return Result.Fail<T>($"{name} cannot be null.");
            return Result.Ok();
        }

        public static Result IfNullOrEmpty(string argument, string name)
        {
            if (string.IsNullOrEmpty(argument)) return Result.Fail($"{name} cannot be null or empty.");
            return Result.Ok();
        }

        public static Result IfNullOrEmpty<T>(IEnumerable<T> argument, string name)
        {
            if (argument == null || !argument.Any()) return Result.Fail($"{name} cannot be null or empty.");
            return Result.Ok();
        }

        public static Result IfNullOrWhiteSpace(string argument, string name)
        {
            if (string.IsNullOrWhiteSpace(argument)) return Result.Fail($"{name} cannot be null or empty or whitespace.");
            return Result.Ok();
        }

        public static Result IfTrue(Func<bool> predicate, string message)
        {
            return predicate() ? Result.Fail(message) : Result.Ok();
        }
        public static Result IfFalse(Func<bool> predicate, string message)
        {
            return !predicate() ? Result.Fail(message) : Result.Ok();
        }
    }
}
