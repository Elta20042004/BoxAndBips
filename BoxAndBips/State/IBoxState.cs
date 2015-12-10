namespace Game.State
{
    public interface IBoxState            //logic
    {
        int Life { get; }

        void DoStep(Box box, Step step);

        bool CanStep(Box box, Step step);
    }
}