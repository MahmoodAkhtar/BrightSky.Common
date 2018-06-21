using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrightSky.Common
{
    public abstract class EnumObject : ValueObject<EnumObject>
    {
        internal class Definition : ValueObject<Definition>
        {
            public static Result<Definition> Create(Type type, int value, string name) => Result.Combine(
                Guard.IfNull(type, nameof(type)),
                Guard.IfNullOrWhiteSpace(name, nameof(name)))
                .Map(() => new Definition(type, value, name));

            protected override IEnumerable<object> GetEqualityComponents()
            {
                yield return Type;
                yield return Value;
                yield return Name;
            }

            public Type Type;
            public string UniqueName { get; }
            public int Value { get; }
            public string Name { get; }

            private Definition(Type type, int value, string name)
            {
                Type = type;
                Value = value;
                Name = name;
            }

            public Result<T> To<T>() where T : EnumObject => Result.Combine(
                Guard.IfTrue(() => {
                    var method = typeof(T).GetMethod("Create", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                    return (method == null);
                }, $"Unable to invoke 'public static Result<T> Create(int value, string name)' factory method on {typeof(T)}."))
                .OnSuccess(() => {
                    var method = typeof(T).GetMethod("Create", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                    return method.Invoke(null, new object[] { Value, Name });
                })
                .Map((result) => result.IsFailure 
                    ? Result.Fail<T>(result.Error)
                    : Result.Ok((T)result.Value));

            public override string ToString()
            {
                return $"{Type}|{Value}|{Name}";
            }
        }

        private static List<Definition> _definitions = new List<Definition>();

        public int Value { get; }
        public string Name { get; }

        protected EnumObject(int value, string name)
        {
            Value = value;
            Name = name;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
            yield return Name;
        }

        public Result Add(EnumObject obj) => Result.Combine(
            Guard.IfNull(obj, nameof(obj)),
            Guard.IfTrue(() => 
                Definition.Create(obj.GetType(), obj.Value, obj.Name).IsFailure,
                Definition.Create(obj.GetType(), obj.Value, obj.Name).Error),
            Guard.IfTrue(() => 
                _definitions.Contains(Definition.Create(obj.GetType(), obj.Value, obj.Name).Value), 
                $"Cannot add duplicate {obj.GetType()} as it already exists."),
            Guard.IfTrue(() => 
                _definitions.Any(x => x.Type == obj.GetType() && x.Value == obj.Value),
                $"Cannot add {obj.GetType()} as there already exists one with the Value = {obj.Value}."))
            .OnSuccess(() => _definitions.Add(Definition.Create(obj.GetType(), obj.Value, obj.Name).Value))
            .Map(() => Result.Ok());

        public static Maybe<T> FromName<T>(Type type, string name) where T : EnumObject => Result.Combine(
            Guard.IfNull(type, nameof(type)),
            Guard.IfNullOrWhiteSpace(name, nameof(name)),
            Guard.IfFalse(() =>
                _definitions.Any(x => x.Name == name && x.UniqueName == $"{type.FullName}.{name}"),
                $"Cannot find any {type.GetType()} with the Name = '{name}'"))
            .OnSuccess(() => _definitions.Where(x => x.Name == name && x.UniqueName == $"{type.FullName}.{name}").Single())
            .Map((definition) => definition.To<T>())
            .Map((result) => result.IsSuccess
                ? Maybe<T>.From(result.Value)
                : Maybe<T>.None).Value;

        public static Maybe<T> FromValue<T>(Type type, int value) where T : EnumObject => Result.Combine(
            Guard.IfNull(type, nameof(type)),
            Guard.IfFalse(() =>
                _definitions.Any(x => x.Value == value && x.Type == type),
                $"Cannot find any {type.GetType()} with the Value = {value}"))
            .OnSuccess(() => _definitions.Where(x => x.Value == value && x.Type == type).Single())
            .Map((definition) => definition.To<T>())
            .Map((result) => result.IsSuccess
                ? Maybe<T>.From(result.Value)
                : Maybe<T>.None).Value;

    }
}
