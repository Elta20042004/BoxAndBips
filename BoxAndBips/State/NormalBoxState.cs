using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxAndBips.State
{
    public class NormalBoxState : LiveBoxState     //bystryj box
    {      
        public NormalBoxState(int life, Box box):base(
            life,
            box,
            new[] {
                new KeyValuePair<Step,Tuple<int, int>>(Step.Left,  new Tuple<int, int>(0,-1)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Right,  new Tuple<int, int>(0,1)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Down,  new Tuple<int, int>(1,0)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Up,  new Tuple<int, int>(-1,0)),
            }.ToDictionary(t => t.Key, t => t.Value))
        {         
        }

        public override void DoStep(Step step)
        {
            _box.World.PutEmptyCell(_box.X, _box.Y); //пустая клетка

            _box.X = _stepMap[step].Item1 + _box.X;
            _box.Y = _stepMap[step].Item2 + _box.Y;


            if (_box.World.GetCell(_box.X, _box.Y) is LifeBip)
            {
                LifeBip pb = (LifeBip)_box.World.GetCell(_box.X, _box.Y);
                Life += pb.Life;
            }
            Life--;

            if (Life > 0 && _box.World.GetCell(_box.X, _box.Y) is SpeedBip)
            {
                _box.State = new FastBoxState(Life - 1, _box);
            }

            _box.World.PutBox(_box, _box.X, _box.Y);
        }
    }
}