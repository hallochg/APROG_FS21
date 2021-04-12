using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SW06_LEDs_RaspberryPi {
    public enum ProcessState {
        no_LED,
        LED_set,
        wait,
        Toggle,
        Periodic_set,
        Periodic_clear,
        Error,
        Error_lednotset,
        Exit
    }

    public enum Command {
        setting_LED,
        toggle,
        set_periodic,
        clear_periodic,
        no_condition,
        terminate
        //Led_changed,
        //function_changed_toggle_led,
        //function_changed_periodic,
        //Exit
    }
    class StateMachine {
        class StateTransition {
            readonly ProcessState CurrentState;
            readonly Command Command;

            public StateTransition(ProcessState currenState, Command command) {
                this.CurrentState = currenState;
                this.Command = command;
            }

            public override int GetHashCode() {
                return 17 + 31 * this.CurrentState.GetHashCode() + 31 * this.Command.GetHashCode();
            }

            public override bool Equals(object obj) {
                StateTransition other = obj as StateTransition;
                return other != null && this.CurrentState == other.CurrentState && this.Command == other.Command;
            }


        }

        Dictionary<StateTransition, ProcessState> transitions;
        public ProcessState CurrentState { get; private set; }

        public StateMachine() {
            CurrentState = ProcessState.no_LED;
            transitions = new Dictionary<StateTransition, ProcessState> {
                {new StateTransition(ProcessState.no_LED, Command.setting_LED), ProcessState.LED_set },
                {new StateTransition(ProcessState.no_LED, Command.clear_periodic), ProcessState.Error_lednotset },
                {new StateTransition(ProcessState.no_LED, Command.set_periodic), ProcessState.Error_lednotset },
                {new StateTransition(ProcessState.no_LED, Command.toggle), ProcessState.Error_lednotset },
                {new StateTransition(ProcessState.no_LED, Command.no_condition), ProcessState.Error_lednotset },
                {new StateTransition(ProcessState.no_LED, Command.terminate), ProcessState.Exit },

                {new StateTransition(ProcessState.LED_set, Command.setting_LED), ProcessState.LED_set },
                {new StateTransition(ProcessState.LED_set, Command.no_condition), ProcessState.wait },
                {new StateTransition(ProcessState.LED_set, Command.set_periodic), ProcessState.Error },
                {new StateTransition(ProcessState.LED_set, Command.toggle), ProcessState.Error },
                {new StateTransition(ProcessState.LED_set, Command.clear_periodic), ProcessState.Error },
                {new StateTransition(ProcessState.LED_set, Command.terminate), ProcessState.Exit },

                {new StateTransition(ProcessState.wait, Command.toggle), ProcessState.Toggle },
                {new StateTransition(ProcessState.wait, Command.set_periodic), ProcessState.Periodic_set },
                {new StateTransition(ProcessState.wait, Command.clear_periodic), ProcessState.Periodic_clear },
                {new StateTransition(ProcessState.wait, Command.setting_LED), ProcessState.LED_set },
                {new StateTransition(ProcessState.wait, Command.no_condition), ProcessState.Error },
                {new StateTransition(ProcessState.wait, Command.terminate), ProcessState.Exit },

                {new StateTransition(ProcessState.Toggle, Command.no_condition), ProcessState.wait },
                {new StateTransition(ProcessState.Toggle, Command.toggle), ProcessState.Error },
                {new StateTransition(ProcessState.Toggle, Command.set_periodic), ProcessState.Error },
                {new StateTransition(ProcessState.Toggle, Command.setting_LED), ProcessState.Error },
                {new StateTransition(ProcessState.Toggle, Command.clear_periodic), ProcessState.Error },
                {new StateTransition(ProcessState.Toggle, Command.terminate), ProcessState.Exit },

                {new StateTransition(ProcessState.Periodic_set, Command.no_condition), ProcessState.wait },
                {new StateTransition(ProcessState.Periodic_set, Command.toggle), ProcessState.Error },
                {new StateTransition(ProcessState.Periodic_set, Command.set_periodic), ProcessState.Error },
                {new StateTransition(ProcessState.Periodic_set, Command.setting_LED), ProcessState.Error },
                {new StateTransition(ProcessState.Periodic_set, Command.clear_periodic), ProcessState.Error },
                {new StateTransition(ProcessState.Periodic_set, Command.terminate), ProcessState.Exit },

                {new StateTransition(ProcessState.Periodic_clear, Command.no_condition), ProcessState.wait },
                {new StateTransition(ProcessState.Periodic_clear, Command.setting_LED), ProcessState.Error },
                {new StateTransition(ProcessState.Periodic_clear, Command.toggle), ProcessState.Error },
                {new StateTransition(ProcessState.Periodic_clear, Command.clear_periodic), ProcessState.Error },
                {new StateTransition(ProcessState.Periodic_clear, Command.set_periodic), ProcessState.Error },
                {new StateTransition(ProcessState.Periodic_clear, Command.terminate), ProcessState.Exit },

                {new StateTransition(ProcessState.Error, Command.no_condition), ProcessState.wait },

                {new StateTransition(ProcessState.Error_lednotset, Command.no_condition), ProcessState.no_LED }


            };
        }

        public ProcessState GetNext(Command command) {
            StateTransition transition = new StateTransition(CurrentState, command);
            ProcessState nextState;
            if (!transitions.TryGetValue(transition, out nextState)) {
                throw new Exception($"Invalid transition: {CurrentState} -> {command}");
            }
            return nextState;
        }

        public ProcessState MoveNext(Command command) {
            CurrentState = GetNext(command);
            return CurrentState;
        }
    }


}
