using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxAndBips.State
{
    public class FastBoxState : IBoxState
    {      
        private readonly Dictionary<Step, Tuple<int, int>> _stepMap;
        private int _stepCounter;
        private readonly Box _box;
        private int _life;

        public FastBoxState(int life, Box box)
        {
            _life = life;
            _box = box;
            _stepMap = new[] {
                new KeyValuePair<Step,Tuple<int, int>>(Step.Left,  new Tuple<int, int>(0,-2)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Right,  new Tuple<int, int>(0,2)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Down,  new Tuple<int, int>(2,0)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Up,  new Tuple<int, int>(-2,0)),
            }.ToDictionary(t => t.Key, t => t.Value);

            _stepCounter = 5;
        }

        public int Life
        {
            get
            {
                return _life;
            }
            set
            {
                _life = value;
                CheckLife();
            }
        }

        private void CheckLife()
        {
            if (Life == 0)
            {
                _box.State = new DeadBoxState();
            }
        }

        public bool IsAlive
        {
            get { return true; }
        }

        public bool CanStep(Box box, Step step)
        {
            int x = _stepMap[step].Item1 + box.X;
            int y = _stepMap[step].Item2 + box.Y;
            BoundValidator validator = new BoundValidator();
            bool result = validator.Validate(box.World, x, y);

            if (result)
            {
                BoxAssaultValidator attack = new BoxAssaultValidator();
                result = attack.Validate(box.World, x, y);
            }
            return result;
        }

        public void DoStep( Step step)
        {
            _box.World.PutEmptyCell(_box.X, _box.Y);

            _box.X = _stepMap[step].Item1 + _box.X;
            _box.Y = _stepMap[step].Item2 + _box.Y;
            _stepCounter--;
            Life--;

            if (_box.World.GetCell(_box.X, _box.Y) is LifeBip)
            {
                LifeBip pb = (LifeBip)_box.World.GetCell(_box.X, _box.Y);
                Life += pb.Life;
            }
            else if (Life == 0)
            {
                _box.State = new DeadBoxState();
            }

            if (_box.World.GetCell(_box.X, _box.Y) is SpeedBip)
            {
                _stepCounter = _stepCounter + 5;
            }
            else if (_stepCounter == 0)
            {
                _box.State = new NormalBoxState(Life, _box);
            }

            _box.World.PutBox(_box, _box.X, _box.Y);
        }
    }
}