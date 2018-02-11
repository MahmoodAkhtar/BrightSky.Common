using System;
using System.Collections.Generic;
using System.Linq;

namespace BrightSky.Common
{
    public static class GuardAgainst
    {
        public static void AnyNulls<T>(IEnumerable<T> arguments, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (arguments.Any(x => x == null))
                throw new ArgumentNullException(name, $"{name} cannot have any null items.");
        }

        public static void EqualTo(int argument, int value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument == value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be equal to {value}.");
        }

        public static void EqualTo(long argument, long value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument == value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be equal to {value}.");
        }

        public static void EqualTo(float argument, float value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument == value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be equal to {value}.");
        }

        public static void EqualTo(double argument, double value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument == value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be equal to {value}.");
        }

        public static void EqualTo(decimal argument, decimal value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument == value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be equal to {value}.");
        }

        public static void GreaterThan(int argument, int value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument > value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than {value}.");
        }

        public static void GreaterThan(long argument, long value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument > value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than {value}.");
        }

        public static void GreaterThan(float argument, float value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument > value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than {value}.");
        }

        public static void GreaterThan(double argument, double value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument > value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than {value}.");
        }

        public static void GreaterThan(decimal argument, decimal value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument > value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than {value}.");
        }

        public static void GreaterThanOrEqualTo(int argument, int value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument >= value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than or equal to {value}.");
        }

        public static void GreaterThanOrEqualTo(long argument, long value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument >= value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than or equal to {value}.");
        }

        public static void GreaterThanOrEqualTo(float argument, float value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument >= value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than or equal to {value}.");
        }

        public static void GreaterThanOrEqualTo(double argument, double value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument >= value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than or equal to {value}.");
        }

        public static void GreaterThanOrEqualTo(decimal argument, decimal value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument >= value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be greater than or equal to {value}.");
        }

        public static void InsideRange(int argument, int min, int max, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument >= min && argument <= max)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be inside the range of min {min} to max {max}.");
        }

        public static void InsideRange(long argument, long min, long max, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument >= min && argument <= max)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be inside the range of min {min} to max {max}.");
        }

        public static void InsideRange(float argument, float min, float max, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument >= min && argument <= max)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be inside the range of min {min} to max {max}.");
        }

        public static void InsideRange(double argument, double min, double max, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument >= min && argument <= max)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be inside the range of min {min} to max {max}.");
        }

        public static void InsideRange(decimal argument, decimal min, decimal max, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument >= min && argument <= max)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be inside the range of min {min} to max {max}.");
        }

        public static void LessThan(int argument, int value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument < value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be less than {value}.");
        }

        public static void LessThan(long argument, long value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument < value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be less than {value}.");
        }

        public static void LessThan(float argument, float value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument < value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be less than {value}.");
        }

        public static void LessThan(double argument, double value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument < value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be less than {value}.");
        }

        public static void LessThan(decimal argument, decimal value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument < value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be less than {value}.");
        }

        public static void LessThanOrEqualTo(int argument, int value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument <= value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be less than or equal to {value}.");
        }

        public static void LessThanOrEqualTo(long argument, long value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument <= value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be less than or equal to {value}.");
        }

        public static void LessThanOrEqualTo(float argument, float value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument <= value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be less than or equal to {value}.");
        }

        public static void LessThanOrEqualTo(double argument, double value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument <= value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be less than or equal to {value}.");
        }

        public static void LessThanOrEqualTo(decimal argument, decimal value, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument <= value)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be less than or equal to {value}.");
        }

        public static void Null<T>(T argument, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument == null)
                throw new ArgumentNullException(name);
        }

        public static void NullOrEmpty(string argument, string name)
        {
            Null(argument, name);
            if (argument == string.Empty)
                throw new ArgumentException($"{name} cannot be an empty string.", name);
        }

        public static void NullOrEmpty<T>(IEnumerable<T> argument, string name)
        {
            Null(argument, name);
            if (!argument.Any())
                throw new ArgumentException($"{name} cannot be empty.", name);
        }

        public static void NullOrEmpty<K, V>(IDictionary<K, V> argument, string name)
        {
            Null(argument, name);
            if (!argument.Any())
                throw new ArgumentException($"{name} cannot be empty.", name);
        }

        public static void NullOrWhitespace(string argument, string name)
        {
            NullOrEmpty(argument, name);
            if (string.IsNullOrWhiteSpace(argument))
                throw new ArgumentException($"{name} cannot be whitespace only.", name);
        }

        public static void OutsideRange(int argument, int min, int max, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument < min || argument > max)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be outside the range of min {min} to max {max}.");
        }

        public static void OutsideRange(long argument, long min, long max, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument < min || argument > max)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be outside the range of min {min} to max {max}.");
        }

        public static void OutsideRange(float argument, float min, float max, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument < min || argument > max)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be outside the range of min {min} to max {max}.");
        }

        public static void OutsideRange(double argument, double min, double max, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument < min || argument > max)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be outside the range of min {min} to max {max}.");
        }

        public static void OutsideRange(decimal argument, decimal min, decimal max, string name)
        {
            ThrowIfNullOrEmpty(nameof(name));
            if (argument < min || argument > max)
                throw new ArgumentOutOfRangeException(name, $"{name} cannot be outside the range of min {min} to max {max}.");
        }

        internal static void ThrowIfNullOrEmpty(string argument)
        {
            if (argument == null)
                throw new ArgumentNullException(argument);
            if (argument == string.Empty)
                throw new ArgumentException($"{argument} cannot be an empty string.", argument);
        }
    }
}