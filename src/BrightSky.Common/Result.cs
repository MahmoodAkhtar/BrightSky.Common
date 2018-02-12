using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;

namespace BrightSky.Common
{
    public struct Result : ISerializable
    {
        private static readonly Result OkResult = new Result(false, null);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        [DebuggerStepThrough]
        private Result(bool isFailure, string error)
        {
            _logic = new ResultCommonLogic(isFailure, error);
        }

        public string Error => _logic.Error;
        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;

        /// <summary>
        /// Returns failure which combined from all failures in the <paramref name="results"/> list. Error messages are separated by <paramref name="errorMessagesSeparator"/>.
        /// If there is no failure returns success.
        /// </summary>
        /// <param name="errorMessagesSeparator">Separator for error messages.</param>
        /// <param name="results">List of results.</param>
        [DebuggerStepThrough]
        public static Result Combine(string errorMessagesSeparator, params Result[] results)
        {
            List<Result> failedResults = results.Where(x => x.IsFailure).ToList();

            if (!failedResults.Any())
                return Ok();

            string errorMessage = string.Join(errorMessagesSeparator, failedResults.Select(x => x.Error).ToArray());
            return Fail(errorMessage);
        }

        [DebuggerStepThrough]
        public static Result Combine(params Result[] results)
        {
            return Combine(", ", results);
        }

        [DebuggerStepThrough]
        public static Result Combine<T>(params Result<T>[] results)
        {
            return Combine(", ", results);
        }

        [DebuggerStepThrough]
        public static Result Combine<T>(string errorMessagesSeparator, params Result<T>[] results)
        {
            Result[] untyped = results.Select(result => (Result)result).ToArray();
            return Combine(errorMessagesSeparator, untyped);
        }

        [DebuggerStepThrough]
        public static Result Fail(string error)
        {
            return new Result(true, error);
        }

        [DebuggerStepThrough]
        public static Result<T> Fail<T>(string error)
        {
            return new Result<T>(true, default(T), error);
        }

        /// <summary>
        /// Returns first failure in the list of <paramref name="results"/>. If there is no failure returns success.
        /// </summary>
        /// <param name="results">List of results.</param>
        [DebuggerStepThrough]
        public static Result FirstFailureOrSuccess(params Result[] results)
        {
            foreach (Result result in results)
            {
                if (result.IsFailure)
                    return Fail(result.Error);
            }

            return Ok();
        }

        [DebuggerStepThrough]
        public static Result Ok()
        {
            return OkResult;
        }

        [DebuggerStepThrough]
        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(false, value, null);
        }

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            oInfo.AddValue("IsFailure", IsFailure);
            oInfo.AddValue("IsSuccess", IsSuccess);
            if (IsFailure)
            {
                oInfo.AddValue("Error", Error);
            }
        }
    }

    public struct Result<T> : ISerializable
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ResultCommonLogic _logic;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly T _value;

        [DebuggerStepThrough]
        internal Result(bool isFailure, T value, string error)
        {
            Invariant.ViolatedBy(
                () => !isFailure && value == null,
                $"{nameof(value)} cannot be null.");

            _logic = new ResultCommonLogic(isFailure, error);
            _value = value;
        }

        public string Error => _logic.Error;
        public bool IsFailure => _logic.IsFailure;
        public bool IsSuccess => _logic.IsSuccess;

        public T Value
        {
            [DebuggerStepThrough]
            get
            {
                var that = this; // cannot capture 'this' as 'this' is a struct

                Invariant.ViolatedBy(
                    () => that.IsFailure,
                    $"There is no {nameof(Value)} for failure.");

                return _value;
            }
        }

        public static implicit operator Result(Result<T> result)
        {
            if (result.IsSuccess)
                return Result.Ok();
            else
                return Result.Fail(result.Error);
        }

        void ISerializable.GetObjectData(SerializationInfo oInfo, StreamingContext oContext)
        {
            oInfo.AddValue("IsFailure", IsFailure);
            oInfo.AddValue("IsSuccess", IsSuccess);
            if (IsFailure)
            {
                oInfo.AddValue("Error", Error);
            }
            else
            {
                oInfo.AddValue("Value", Value);
            }
        }
    }

    internal sealed class ResultCommonLogic
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _error;

        [DebuggerStepThrough]
        public ResultCommonLogic(bool isFailure, string error)
        {
            Invariant.ViolatedBy(
                () => isFailure && string.IsNullOrEmpty(error),
                $"There must be an error message for failure, {nameof(error)} cannot be null or empty.");

            Invariant.ViolatedBy(
                () => isFailure == false && error != null,
                $"There must be no error message for success, {nameof(error)} must be null.");

            IsFailure = isFailure;
            _error = error;
        }

        public string Error
        {
            [DebuggerStepThrough]
            get
            {
                Invariant.ViolatedBy(
                    () => IsSuccess,
                    $"There is no {nameof(Error)} for success.");

                return _error;
            }
        }

        public bool IsFailure { get; }
        public bool IsSuccess => !IsFailure;
    }
}