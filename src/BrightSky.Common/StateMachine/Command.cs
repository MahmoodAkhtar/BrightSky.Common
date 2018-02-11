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

        public static Command Create(string name)
        {
            GuardAgainst.NullOrWhitespace(name, nameof(name));

            return new Command(name);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}