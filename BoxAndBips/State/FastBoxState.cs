using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.State
{
    public class FastBoxState : IBoxState
    {
        public int Life { get; private set; }
        private readonly Dictionary<Step, Tuple<int, int>> _stepMap;
        private int _stepCounter;
        public FastBoxState(int life)
        {
            Life = life;
            _stepMap = new[] {
                new KeyValuePair<Step,Tuple<int, int>>(Step.Left,  new Tuple<int, int>(0,-2)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Right,  new Tuple<int, int>(0,2)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Down,  new Tuple<int, int>(2,0)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Up,  new Tuple<int, int>(-2,0)),
            }.ToDictionary(t => t.Key, t => t.Value);

            _stepCounter = 5;
        }

        public bool CanStep(Box box, Step step)
        {
            BoundValidator validator = new BoundValidator();
            bool result = validator.Validator(
                box.World,
                _stepMap[step].Item1 + box.X,
                _stepMap[step].Item2 + box.Y);
            return result;
        }


        public void DoStep(Box box, Step step)
        {
            box.World.PutEmptyCell(box.X, box.Y);

            box.X = _stepMap[step].Item1 + box.X;
            box.Y = _stepMap[step].Item2 + box.Y;
            _stepCounter--;
            Life--;

            if (box.World.GetCell(box.X, box.Y) is LifeBip)
            {
                LifeBip pb = (LifeBip)box.World.GetCell(box.X, box.Y);
                Life += pb.Life;
            }
            else if (Life == 0)
            {
                box.State = new DeadBoxState();
            }

            if (box.World.GetCell(box.X, box.Y) is SpeedBip)
            {
                _stepCounter = _stepCounter + 5;
            }
            else if (_stepCounter == 0)
            {
                box.State = new NormalBoxState(Life);
            }

            box.World.PutBox(box, box.X, box.Y);
        }
    }
}