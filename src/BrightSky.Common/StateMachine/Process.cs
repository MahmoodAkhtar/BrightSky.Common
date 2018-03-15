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

        public static Result<Process> Create(IEnumerable<Transition> transitions, State state) => Result.Combine(
            Guard.IfNullOrEmpty(transitions, nameof(transitions)),
            Guard.IfNull(state, nameof(state)),
            Guard.IfViolatedBy(
                () => transitions.Any(x => x.Start != state || x.End != state),
                $"{nameof(transitions)} has a transition that does not start with or end with state {state.GetType()}."))
            .Map(() => new Process(transitions, state));

        public Result<State> MoveNext(Command command) => Result.Combine(
            Guard.IfNull(command, nameof(command)),
            Guard.IfSatisfiedBy(
                () => _transitions.Any(x => x.Start == CurrentState && x.Command == command),
                $"Current state {CurrentState.GetType()} does not accept the command {command.GetType()}."))
            .OnSuccess(() => CurrentState.RunExitActions(command))
            .Map(() => _transitions.Where(x => x.Start == CurrentState && x.Command == command).Select(x => x.End).First())
            .OnSuccess(x =>
            {
                x.RunEnterActions(command);
            });

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