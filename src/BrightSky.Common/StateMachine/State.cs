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

        public static State Create(string name)
        {
            GuardAgainst.NullOrWhitespace(name, nameof(name));

            return new State(name);
        }

        public void RunEnterActions(Command command)
        {
            _logic.RunActions(this, command, _enterActions, _enterCatchAction);
        }

        public void RunExitActions(Command command)
        {
            _logic.RunActions(this, command, _exitActions, _exitCatchAction);
        }

        public void SetEnterActions(IEnumerable<Action<State, Command>> actions, Action<Exception> catchAction)
        {
            (_enterActions, _enterCatchAction) = _logic.GetActions(this, actions, catchAction);
        }

        public void SetExitActions(IEnumerable<Action<State, Command>> actions, Action<Exception> catchAction)
        {
            (_exitActions, _exitCatchAction) = _logic.GetActions(this, actions, catchAction);
        }

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
            public (IEnumerable<Action<State, Command>>, Action<Exception>) GetActions(State state, IEnumerable<Action<State, Command>> actions, Action<Exception> catchAction)
            {
                GuardAgainst.Null(state, nameof(state));
                GuardAgainst.NullOrEmpty(actions, nameof(actions));
                GuardAgainst.Null(catchAction, nameof(catchAction));

                Invariant.SatisfiedBy(
                    () => actions.All(x => x.Method.GetParameters().All(y => y.Position == 0 && y.ParameterType == state.GetType())),
                    $"{nameof(actions)} contains an action with the wrong state type, expected {state.GetType()}.");

                return (actions, catchAction);
            }

            public void RunActions(State state, Command command, IEnumerable<Action<State, Command>> actions, Action<Exception> catchAction)
            {
                GuardAgainst.Null(state, nameof(state));
                GuardAgainst.Null(command, nameof(command));
                GuardAgainst.NullOrEmpty(actions, nameof(actions));
                GuardAgainst.Null(catchAction, nameof(catchAction));

                Invariant.SatisfiedBy(
                    () => actions.All(x => x.Method.GetParameters().All(y => y.Position == 0 && y.ParameterType == state.GetType())),
                    $"{nameof(actions)} contains an action with the wrong state type, expected {state.GetType()}.");

                Invariant.SatisfiedBy(
                    () => actions.Any(x => x.Method.GetParameters().Any(y => y.Position == 1 && y.ParameterType == command.GetType())),
                    $"{nameof(actions)} does not contain an action with the command type {command.GetType()}.");

                var commandActions = actions
                    .Where(x => x.Method.GetParameters().Where(y => y.Position == 1 && y.ParameterType == command.GetType()).Any())
                    .Select(x => new Action(() => x(state, command)))
                    .ToArray();

                if (commandActions.Any())
                {
                    Handling.TryCatch(
                        () => Parallel.Invoke(commandActions),
                        catchAction);
                }
            }
        }
    }
}