

namespace Turing_Machine.TuringMachineLib
{
    struct State
    {
        public string name;
        public int index;

        public State(string name, int index)
        {
            this.name = name;
            this.index = index;
        }
        public static bool operator ==(State s1, State s2)
        {
            return s1.index == s2.index;
        }
        public static bool operator !=(State s1, State s2)
        {
            return s1.index != s2.index;
        }
        public override string ToString()
        {
            return name;
        }

    }
    
}
