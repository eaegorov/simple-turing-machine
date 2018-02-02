using System;
using System.Collections.Generic;

namespace Turing_Machine.TuringMachineLib
{
    public enum Action { HOLD, MOVE_LEFT, MOVE_RIGHT }

    struct Transition
    {
        public Transition(
            string currentState,
            List<char> currentChars,
            string newState,
            List<char> newChars,
            List<Action> actions)
        {
            this.currentState = currentState;
            this.currentChars = currentChars;
            this.newState = newState;
            this.newChars = newChars;
            this.actions = actions;
        }
        public string currentState;
        public List<char> currentChars;
        public string newState;
        public List<char> newChars;
        public List<Action> actions;
    }
}
