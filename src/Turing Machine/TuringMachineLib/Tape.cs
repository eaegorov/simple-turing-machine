using System.Collections.Generic;


namespace Turing_Machine.TuringMachineLib
{
    public class Tape
    {
        Dictionary<int, char> Data;
        int currentIndex = 0;
        int leftIndex = 0;
        int rightIndex = 0;

        public void ResetIndex()
        {
           currentIndex = 0;
        }

        public Tape()
        {
            this.Data = new Dictionary<int, char>();
        }

        public void Clear()
        {
            this.Data.Clear();
            currentIndex = 0;
            rightIndex = 0;
            leftIndex = 0;
        }

        public void Write(char value)
        {
            this.Data[currentIndex] = value;
        }
        public char Read()
        {
            char c;
            if (this.Data.TryGetValue(currentIndex, out c))
                return c;
            else
                return '_';
        }

        public char Read(int index)
        {
            char c;
            if (this.Data.TryGetValue(index, out c))
                return c;
            else
                return '_';
        }

        public void HandleAction(Action action)
        {
            switch (action)
            {
                case Action.HOLD:
                    break;
                case Action.MOVE_LEFT:
                    MoveLeft();
                    break;
                case Action.MOVE_RIGHT:
                    MoveRight();
                    break;
                default:
                    break;
            }
        }

        public string GetData()
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = leftIndex; i <= rightIndex; i++)
                sb.Append(Read(i));

            return sb.ToString();
        }
   
        public void MoveRight() {
            currentIndex++;
            if (currentIndex > rightIndex)
                rightIndex = currentIndex;
        }
        public void MoveLeft()
        {
            currentIndex--;
            if (currentIndex < leftIndex)
                leftIndex = currentIndex;
        }

        public int CurrentIndex()
        {
            return currentIndex;
        }
       
    }
    

}
