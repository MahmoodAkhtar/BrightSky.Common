using BrightSky.Common.Extensions;
using System.Collections.Generic;

namespace BrightSky.Common.StateMachine
{
    public class Command : ValueObject<Command>
    {
        public string Name { get; }

        protected Command(string name)
        {
            Name = name;
        }

        public static Result<Command> Create(string name) => Result.Combine(
            Guard.IfNullOrWhiteSpace(name, nameof(name)))
            .Map(() => new Command(name));

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}