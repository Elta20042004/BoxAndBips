using System;
using System.Collections.Generic;
using System.Text;
using Game.Rule;

namespace Game
{
    public class World
    {
        private readonly IEnumerable<IRule> _setOfRules;
        private readonly List<Box> _boxes;       
        private readonly ICell[,] _gridCells;

        public World(int m, int n, IEnumerable<IRule> setOfRules)
        {
            _setOfRules = setOfRules;
            M = m;
            N = n;
            _boxes = new List<Box>();
            _gridCells = new ICell[m, n];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    _gridCells[i, j] = new EmptyCell();
                }
            }
        }

        public int M { get; }

        public int N { get; }

        public void ApplyRules()
        {
            foreach (var rule in _setOfRules)
            {
                foreach (var box in _boxes)
                {
                    rule.Apply(box,this);
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
            _boxes.Add(box);
        }
     
        public void PutEmptyCell(int x, int y) 
        {
            _gridCells[x,y] = new EmptyCell();
        }

        public ICell GetCell(int x, int y)
        {
            if ((x < M && x >= 0) && (y < N && y >= 0))
            {
                return _gridCells[x, y];
            }
            else
            {
                return null;
            }
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