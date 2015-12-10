namespace Game.State
{
    public class DeadBoxState : IBoxState
    {
        public int Life { get { return 0; } }
        public void DoStep(Box box, Step step)
        {
            throw new System.InvalidOperationException("I'm dead!!!");
        }

        public bool CanStep(Box box, Step step)
        {
            return false;
        }
    }
}