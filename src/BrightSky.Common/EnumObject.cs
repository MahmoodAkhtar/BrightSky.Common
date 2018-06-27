using BrightSky.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrightSky.Common
{
    internal class EnumObjectDefinition<T> : ValueObject<EnumObjectDefinition<T>> where T : EnumObject<T>
    {
        public static Result<EnumObjectDefinition<T>> Create(Type type, int value, string name) => Result.Combine(
            Guard.IfNull(type, nameof(type)),
            Guard.IfNullOrWhiteSpace(name, nameof(name)))
            .Map(() => new EnumObjectDefinition<T>(type, value, name));

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Type;
            yield return Value;
            yield return Name;
        }

        public Type Type;
        public int Value { get; }
        public string Name { get; }

        private EnumObjectDefinition(Type type, int value, string name)
        {
            Type = type;
            Value = value;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public abstract class EnumObject<T> where T : EnumObject<T>
    {
        internal static List<EnumObjectDefinition<T>> Definitions = new List<EnumObjectDefinition<T>>();

        public int Value { get; private set; }
        public string Name { get; private set; }

        public IReadOnlyList<EnumObject<T>> Items => Definitions.Select(x => x.To().Value).ToList().AsReadOnly();

        protected EnumObject(int value, string name)
        {
            Value = value;
            Name = name;
        }

        public static bool operator !=(EnumObject<T> a, EnumObject<T> b)
        {
            return !(a == b);
        }

        public static bool operator ==(EnumObject<T> a, EnumObject<T> b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            var enumObject = obj as EnumObject<T>;

            if (enumObject is null)
                return false;

            if (GetType() != obj.GetType())
                return false;

            return GetEqualityComponents().SequenceEqual(enumObject.GetEqualityComponents());
        }

        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Aggregate(1, (current, obj) =>
                {
                    unchecked
                    {
                        return current * 23 + (obj?.GetHashCode() ?? 0);
                    }
                });
        }

        public override string ToString()
        {
            return Name;
        }

        protected IEnumerable<object> GetEqualityComponents()
        {
            yield return GetType();
            yield return Value;
            yield return Name;
        }

        protected static Result Add(EnumObject<T> obj) => Result.Combine(
            Guard.IfNull(obj, nameof(obj)),
            Guard.IfTrue(() =>
                EnumObjectDefinition<T>.Create(typeof(T), obj.Value, obj.Name).IsFailure,
                EnumObjectDefinition<T>.Create(typeof(T), obj.Value, obj.Name).Error))
            .OnSuccess(() =>
            {
                var def = EnumObjectDefinition<T>.Create(typeof(T), obj.Value, obj.Name).Value;
                if (!Definitions.Contains(def)) Definitions.Add(def);
                return Result.Ok();
            });

        public static Maybe<T> FromName(string name) => Result.Combine(
            Guard.IfFalse(() =>
                {
                    if (!typeof(T).GetConstructors(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).Any()) return false;

                    return Handling.TryCatch<Exception>(
                        () => System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle),
                        (e) => false);
                },
                $"{typeof(T)} missing static constructor or an exception occured trying to call the static constructor."),
            Guard.IfNullOrWhiteSpace(name, nameof(name)),
            Guard.IfFalse(() =>
                Definitions.Any(x => x.Name == name && x.Type == typeof(T)),
                $"Cannot find any {typeof(T)} with the Name = '{name}'"))
            .OnSuccess(() => Definitions.Where(x => x.Name == name && x.Type == typeof(T)).Single())
            .Map((definition) => definition.To())
            .Map((result) => result.IsSuccess
                ? Maybe<T>.From(result.Value)
                : Maybe<T>.None).Value;

        public static Maybe<T> FromValue(int value) => Result.Combine(
            Guard.IfFalse(() =>
                {
                    if (!typeof(T).GetConstructors(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).Any()) return false;

                    return Handling.TryCatch<Exception>(
                        () => System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle),
                        (e) => false);
                },
                $"{typeof(T)} missing static constructor or an exception occured trying to call the static constructor."),
            Guard.IfFalse(() =>
                Definitions.Any(x => x.Value == value && x.Type == typeof(T)),
                $"Cannot find any {typeof(T)} with the Value = {value}"))
            .OnSuccess(() => Definitions.Where(x => x.Value == value && x.Type == typeof(T)).Single())
            .Map((definition) => definition.To())
            .Map((result) => result.IsSuccess
                ? Maybe<T>.From(result.Value)
                : Maybe<T>.None).Value;
    }
}