using System.Collections.Generic;

namespace Turing_Machine.TuringMachineLib
{
    class TuringMachine
    {

        const int DEFAULT_TAPE_SIZE = 20;

        public List<Tape> tapes;
        public List<Transition> transitions;
        public List<string> acceptStates;

        public string initState;
        private string currentState;

        public bool hasInitState = false;
        public bool isFinished = false;
        private int stepCount = 0;
        private bool isAccepted = false;

        public bool IsAccepted()
        {
            return isAccepted;
        }

        public bool IsFinished()
        {
            return isFinished;
        }

        public string CurrentState
        {
            get
            {
                return currentState;
            }

            set
            {
                if (!hasInitState)
                    hasInitState = true;
                currentState = value;
            }
        }

        public int StepCount()
        {
            return stepCount;
        }




        public TuringMachine()
        {
            this.tapes = new List<Tape>();
            this.transitions = new List<Transition>(DEFAULT_TAPE_SIZE);
            this.acceptStates = new List<string>();
            stepCount = 0;
        }

        public TuringMachine(string initState, int tapeCount)
        {
            this.CurrentState = initState;
            this.tapes = new List<Tape>();
            for (int i = 0; i < tapeCount; i++)
                tapes.Add(new Tape());
            this.transitions = new List<Transition>(DEFAULT_TAPE_SIZE);
            this.acceptStates = new List<string>();
            stepCount = 0;
        }
        


       

        public void Add_AcceptState(string stateName)
        {
            if ( acceptStates.Contains(stateName) )                       // Avoid identical accepting states
                return;

            
            this.acceptStates.Add(stateName);
        }

        public void AddTransition(Transition transition)
        {
            this.transitions.Add(transition);
        }

        public void ReadInput(ref List<char> input)
        {
            foreach(Tape tape in this.tapes)
            {
                tape.Clear();
            }
            if (tapes == null || tapes.Count == 0)
                return;
            foreach(char c in input)                                // Input is written only in first tape
            {
                this.tapes[0].Write(c);
                this.tapes[0].MoveRight();
            }

            this.tapes[0].ResetIndex();
            this.isFinished = false;
            this.stepCount = 0;
            this.currentState = this.initState;
        }

        public void PrintOutput()
        {
            foreach(Tape t in tapes)
            {
                string s = t.GetData();
                System.Console.WriteLine(s);
            }
        }

        public void performTransition(Transition T)
        {
            this.currentState = T.newState;
            for(int i = 0; i < T.newChars.Count; i++)
            {
                this.tapes[i].Write(T.newChars[i]);
                this.tapes[i].HandleAction(T.actions[i]);
            }
        }

        public bool checkTransition(Transition T)
        {
            if (this.currentState != T.currentState)
                return false;

            for(int i = 0; i < T.currentChars.Count; i++)
            {
                if (this.tapes[i].Read() != T.currentChars[i])
                    return false;
            }

            return true;
        }

        public void Tick()
        {                        
            Stack<Transition> matchingTransitions = new Stack<Transition>();

            foreach(Transition t in transitions)
            {
                if (checkTransition(t))
                    matchingTransitions.Push(t);
            }

            if (matchingTransitions.Count == 1)
            {
                stepCount++;
                performTransition(matchingTransitions.Peek());
            }

            if (matchingTransitions.Count >= 2)
            {
                System.Console.WriteLine("TRANSITION COLLISION");           // Non-determenistic case
            }




            if ( matchingTransitions.Count == 0)
            {
                isFinished = true;
                if (this.acceptStates.Contains(currentState))
                    isAccepted = true;
                else
                    currentState = "Rejected";
            }

         
        }

    }
}
