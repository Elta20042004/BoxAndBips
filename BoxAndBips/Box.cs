using System;
using Game.State;

namespace Game
{
    public class Box : IItem
    {
        public int X { get;  set; }
        public int Y { get;  set; }

        public string Name { get; private set; }       
        public World World { get; private set; }

        public Box(string name, int life, World world)
        {
            Name = name;
            World = world;
            State = new NormalBoxState(life);
        }

        public IBoxState State { get; set; }

        public bool StepDown()
        {
            return MakeStep(Step.Down);
        }

        public bool StepUp()
        {
            return MakeStep(Step.Up);
        }

        public bool StepLeft()
        {
            return MakeStep(Step.Left);
        }

        public bool StepRight()
        {
            return MakeStep(Step.Right);
        }

        private bool MakeStep(Step value)
        {
            if (State.CanStep(this, value))
            {
                State.DoStep(this, value);
                return true;
            }

            return false;
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