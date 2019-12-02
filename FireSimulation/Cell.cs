using System;
using System.Collections.Generic;
using System.Text;

namespace FireSimulation
{
    class Cell
    {
       // State can be ' ', '&' or 'X' for empty, tree and burning correspondingly
        public char State
        {
            get;
            set;
        }

        public Cell()
        {

        }

        public void SetState(char state)
        {
            State = state;
        }

        public char GetState()
        {
            return State;
        }
    }
}
