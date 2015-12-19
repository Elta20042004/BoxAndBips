namespace BoxAndBips.State
{
    public interface IBoxState            //logic
    {
        int Life { get; set; }

        void DoStep(Step step);

        bool CanStep(Box box, Step step);

        bool IsAlive { get; }
    }
}