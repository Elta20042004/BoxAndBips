using System;

namespace BoxAndBips.State
{
    public class DeadBoxState : IBoxState
    {
        public int Life
        {
            get
            {
                return 0;
            }
            set
            {
                throw new ArgumentException("I'm dead!!!");
            }
        }

        public void DoStep(Step step)
        {
            throw new System.InvalidOperationException("I'm dead!!!");
        }

        public bool CanStep(Box box, Step step)
        {
            return false;
        }

        public bool IsAlive
        {
            get { return false; } 
        }
    }
}