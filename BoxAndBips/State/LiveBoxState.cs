using System;
using System.Collections.Generic;

namespace BoxAndBips.State
{
    public abstract class LiveBoxState : IBoxState
    {
        protected readonly Dictionary<Step, Tuple<int, int>> _stepMap;
        protected readonly Box _box;
        protected int _life;

        public LiveBoxState(int life, Box box, Dictionary<Step, Tuple<int, int>> stepMap)
        {
            Life = life;
            this._box = box;
            this._stepMap = stepMap;
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

        public abstract void DoStep(Step step);

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
    }
}