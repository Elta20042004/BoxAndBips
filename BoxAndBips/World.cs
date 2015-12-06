namespace Game
{
    public class World
    {
        public int M { get; }
        public int N { get; }
        private readonly ICell[,] _gridCells;

        public World(int m, int n)
        {
            M = m;
            N = n;
            _gridCells = new ICell[m, n];
        }

        public void PutPointBip(int x, int y, int points)
        {
            Bip pointBip = new PointBip();               
            _gridCells[x, y] = pointBip;
        }
        public void PutSpeedBip(int x, int y, int speed)
        {
            Bip speedBip = new SpeedBip();
            _gridCells[x, y] = speedBip;
        }

        public void PutBox(Box box, int x, int y)
        {
            _gridCells[x, y] = box;
        }

        public void PutEmptyCell(int x, int y)
        {
            _gridCells[x,y] = new EmptyCell();
        }

        public ICell GetCell(int x, int y)
        {
            return _gridCells[x, y];
        }
    }
}