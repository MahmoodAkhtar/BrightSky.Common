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

        public static Transition Create(State start, Command command, State end)
        {
            GuardAgainst.Null(start, nameof(start));
            GuardAgainst.Null(command, nameof(command));
            GuardAgainst.Null(end, nameof(end));

            return new Transition(start, command, end);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Start;
            yield return Command;
            yield return End;
        }
    }
}