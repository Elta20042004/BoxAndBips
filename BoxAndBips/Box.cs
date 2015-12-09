using System;
using Game.State;

namespace Game
{
    public class Box : IItem
    {
        public int X { get;  set; }
        public int Y { get;  set; }

        public World World { get; }

        public Box(World world)
        {
            World = world;
            State = new NormalBoxState();
        }

        public IBoxState State { get; set; }

        public void StepDown()
        {
            bool ok = State.CanStep(this, Step.Down);
            if (ok)
            {
                State.DoStep(this,Step.Down);
            }
        }

        public void StepUp()
        {
            bool ok = State.CanStep(this, Step.Up);
            if (ok)
            {
                State.DoStep(this, Step.Up);
            }
        }

        public void StepLeft()
        {
            bool ok = State.CanStep(this, Step.Left);
            if (ok)
            {
                State.DoStep(this, Step.Left);
            }
        }

        public void StepRight()
        {
            bool ok = State.CanStep(this, Step.Right);
            if (ok)
            {
                State.DoStep(this, Step.Right);
            }
        }



        public void Remove()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "@";
        }
    }
}