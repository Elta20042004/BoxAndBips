using System;
using System.Collections.Generic;
using System.Linq;

namespace Game.State
{
    public class NormalBoxState : IBoxState     //bystryj box
    {
        public int Life { get; private set; }
        private readonly Dictionary<Step, Tuple<int, int>> _stepMap;
        public NormalBoxState(int life)
        {
            Life = life;
            _stepMap = new[] {
                new KeyValuePair<Step,Tuple<int, int>>(Step.Left,  new Tuple<int, int>(0,-1)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Right,  new Tuple<int, int>(0,1)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Down,  new Tuple<int, int>(1,0)),
                new KeyValuePair<Step,Tuple<int, int>>(Step.Up,  new Tuple<int, int>(-1,0)),
            }.ToDictionary(t => t.Key, t => t.Value);
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
            box.World.PutEmptyCell(box.X, box.Y); //пустая клетка

            box.X = _stepMap[step].Item1 + box.X;
            box.Y = _stepMap[step].Item2 + box.Y;
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
            else if (box.World.GetCell(box.X, box.Y) is SpeedBip)
            {
                box.State = new FastBoxState(Life);
            }
            
            box.World.PutBox(box, box.X, box.Y);
        }
    }
}