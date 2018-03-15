using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrightSky.Common.StateMachine
{
    public class State : ValueObject<State>
    {
        private readonly StateCommonLogic _logic;

        private IEnumerable<Action<State, Command>> _enterActions;
        private Action<Exception> _enterCatchAction;
        private IEnumerable<Action<State, Command>> _exitActions;
        private Action<Exception> _exitCatchAction;

        protected State(string name)
        {
            Name = name;
            _logic = new StateCommonLogic();
            _enterActions = new List<Action<State, Command>>();
            _enterCatchAction = new Action<Exception>((x) => { });
            _exitActions = new List<Action<State, Command>>();
            _exitCatchAction = new Action<Exception>((x) => { });
        }

        public string Name { get; }

        public Result<State> Create(string name) => Result.Combine(
            Guard.IfNullOrWhiteSpace(name, nameof(name)))
            .Map(() => new State(name));

        public Result RunEnterActions(Command command) => Result.Combine(
            Guard.IfNull(command, nameof(command)))
            .OnSuccess(() => _logic.RunActions(this, command, _enterActions, _enterCatchAction));

        public Result RunExitActions(Command command) => Result.Combine(
            Guard.IfNull(command, nameof(command)))
            .OnSuccess(() => _logic.RunActions(this, command, _exitActions, _exitCatchAction));

        public Result SetEnterActions(IEnumerable<Action<State, Command>> actions, Action<Exception> catchAction) => Result.Combine(
            Guard.IfNullOrEmpty(actions, nameof(actions)),
            Guard.IfNull(catchAction, nameof(catchAction)))
            .OnSuccess(() => _logic.FilterActionsForState(this, actions, catchAction))
            .OnSuccess(x => (_enterActions, _enterCatchAction) = x);

        public Result SetExitActions(IEnumerable<Action<State, Command>> actions, Action<Exception> catchAction) => Result.Combine(
            Guard.IfNullOrEmpty(actions, nameof(actions)),
            Guard.IfNull(catchAction, nameof(catchAction)))
            .OnSuccess(() => _logic.FilterActionsForState(this, actions, catchAction))
            .OnSuccess(x => (_exitActions, _exitCatchAction) = x);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;

            foreach (var enterAction in _enterActions)
            {
                yield return enterAction;
            }

            yield return _enterCatchAction;

            foreach (var exitAction in _exitActions)
            {
                yield return exitAction;
            }

            yield return _exitCatchAction;
        }

        internal sealed class StateCommonLogic
        {
            public Result<Tuple<IEnumerable<Action<State, Command>>, Action<Exception>>> FilterActionsForState(State state, IEnumerable<Action<State, Command>> actions, Action<Exception> catchAction) => Result.Combine(
                Guard.IfNull(state, nameof(state)),
                Guard.IfNullOrEmpty(actions, nameof(actions)),
                Guard.IfNull(catchAction, nameof(catchAction)),
                Guard.IfSatisfiedBy(
                    () => actions.All(x => x.Method.GetParameters().All(y => y.Position == 0 && y.ParameterType == state.GetType())),
                    $"{nameof(actions)} contains an action with the wrong state type, expected {state.GetType()}."))
                .Map(() => Tuple.Create(actions, catchAction));

            public Result RunActions(State state, Command command, IEnumerable<Action<State, Command>> actions, Action<Exception> catchAction) => Result.Combine(
                Guard.IfNull(state, nameof(state)),
                Guard.IfNull(command, nameof(command)),
                Guard.IfNullOrEmpty(actions, nameof(actions)),
                Guard.IfNull(catchAction, nameof(catchAction)),
                Guard.IfSatisfiedBy(
                    () => actions.All(x => x.Method.GetParameters().All(y => y.Position == 0 && y.ParameterType == state.GetType())),
                    $"{nameof(actions)} contains an action with the wrong state type, expected {state.GetType()}."),
                Guard.IfSatisfiedBy(
                    () => actions.Any(x => x.Method.GetParameters().Any(y => y.Position == 1 && y.ParameterType == command.GetType())),
                    $"{nameof(actions)} does not contain any action with the command type {command.GetType()}."))
                .Map(
                    () => actions.Where(x => x.Method.GetParameters().Any(y => y.Position == 1 && y.ParameterType == command.GetType()))
                                 .Select(x => new Action(() => x(state, command))).ToArray())
                .OnSuccess(x =>
                {
                    if (x.Any())
                    {
                        Handling.TryCatch(() => Parallel.Invoke(x), catchAction);
                    }
                });
        }
    }
}