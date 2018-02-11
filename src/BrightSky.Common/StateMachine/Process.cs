using System.Collections.Generic;
using System.Linq;

namespace BrightSky.Common.StateMachine
{
    public class Process : ValueObject<Process>
    {
        private IEnumerable<Transition> _transitions;

        private Process(IEnumerable<Transition> transitions, State state)
        {
            _transitions = transitions;
            CurrentState = state;
        }

        public State CurrentState { get; private set; }

        public static Process Create(IEnumerable<Transition> transitions, State state)
        {
            GuardAgainst.NullOrEmpty(transitions, nameof(transitions));
            GuardAgainst.Null(state, nameof(state));

            Invariant.SatisfiedBy(
                () => transitions.Any(x => x.Start != state && x.End != state),
                $"State {state.Name} does not exit in any {nameof(transitions)}.");

            return new Process(transitions, state);
        }

        public State MoveNext(Command command)
        {
            GuardAgainst.Null(command, nameof(command));

            Invariant.SatisfiedBy(
                () => _transitions.Any(x => x.Start == CurrentState && x.Command == command),
                $"Current state {CurrentState.Name} does not accept the command {command.Name}.");

            CurrentState.RunExitActions(command);

            CurrentState = _transitions.Where(x => x.Start == CurrentState && x.Command == command).Select(x => x.End).First();

            CurrentState.RunEnterActions(command);

            return CurrentState;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CurrentState;

            foreach (var transition in _transitions)
            {
                yield return transition;
            }
        }
    }
}