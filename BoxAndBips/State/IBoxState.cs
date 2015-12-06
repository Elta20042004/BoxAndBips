namespace Game.State
{
    public interface IBoxState            //logic
    {
        void DoStep(Box box, Step step);

        bool CanStep(Box box, Step step);

        bool IsALive(Box box);
    }
}