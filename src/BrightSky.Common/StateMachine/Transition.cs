using BrightSky.Common.Extensions;
using System.Collections.Generic;

namespace BrightSky.Common.StateMachine
{
    public class Transition : ValueObject<Transition>
    {
        public State Start { get; }
        public Command Command { get; }
        public State End { get; }

        private Transition(State start, Command command, State end)
        {
            Start = start;
            Command = command;
            End = end;
        }

        public static Result<Transition> Create(State start, Command command, State end) => Result.Combine(
            Guard.IfNull(start, nameof(start)),
            Guard.IfNull(command, nameof(command)),
            Guard.IfNull(end, nameof(end)))
            .Map(() => new Transition(start, command, end));

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return Command;
            yield return End;
        }
    }
}