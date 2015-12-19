namespace BoxAndBips
{
    public interface IWorld
    {
        int M { get; }

        int N { get; }

        void ApplyRules();

        void PutLifeBip(int x, int y, int life);

        void PutSpeedBip(int x, int y, int speed);

        void PutBox(Box box, int x, int y);

        void PutEmptyCell(int x, int y);

        ICell GetCell(int x, int y);
    }
}