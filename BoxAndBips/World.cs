using System;
using System.Text;

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
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    _gridCells[i, j] = new EmptyCell();
                }
            }
        }

        public void PutLifeBip(int x, int y, int life)
        {
            Bip lifeBip = new LifeBip(life);               
            _gridCells[x, y] = lifeBip;
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

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();            
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (_gridCells[i, j] ==null)
                        throw new ArgumentException();
                    builder.Append(_gridCells[i, j]);
                }
                builder.Append("\n\r");
            }
            return builder.ToString();
        }
    }
}