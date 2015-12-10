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

        public void StepDown()
        {
            MakeStep(Step.Down);
        }

        public void StepUp()
        {
            MakeStep(Step.Up);
        }

        public void StepLeft()
        {
            MakeStep(Step.Left);
        }

        public void StepRight()
        {
            MakeStep(Step.Right);
        }

        private void MakeStep(Step value)
        {
            if (State.CanStep(this, value))
            {
                State.DoStep(this, value);
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