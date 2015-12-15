using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.State
{
    public class NormalBoxState : IBoxState     //bystryj box
    {
        private readonly Dictionary<Step, Tuple<int, int>> _stepMap;
        private readonly Box _box;
        private int _life;


        public NormalBoxState(int life, Box box)
        {
            _life = life;
            _box = box;
            _stepMap = new[] {
                new KeyValuePair<Step,Tuple<int, int>>(Step.Left,  new Tuple<int, int>(0,-1)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Right,  new Tuple<int, int>(0,1)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Down,  new Tuple<int, int>(1,0)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Up,  new Tuple<int, int>(-1,0)),
            }.ToDictionary(t => t.Key, t => t.Value);
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
            BoundValidator validator = new BoundValidator();
            bool result = validator.Validator(
                box.World,
                _stepMap[step].Item1 + box.X,
                _stepMap[step].Item2 + box.Y);
            return result;
        }

        public void DoStep(Step step)
        {
            _box.World.PutEmptyCell(_box.X, _box.Y); //пустая клетка

            _box.X = _stepMap[step].Item1 + _box.X;
            _box.Y = _stepMap[step].Item2 + _box.Y;
            Life--;

            if (_box.World.GetCell(_box.X, _box.Y) is LifeBip)
            {
                LifeBip pb = (LifeBip)_box.World.GetCell(_box.X, _box.Y);
                Life += pb.Life;
            }
            else if (_box.World.GetCell(_box.X, _box.Y) is SpeedBip)
            {
                _box.State = new FastBoxState(Life, _box);
            }

            _box.World.PutBox(_box, _box.X, _box.Y);
        }
    }
}