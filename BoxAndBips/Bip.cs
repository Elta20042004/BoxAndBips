using System;

namespace Game
{
    public abstract class Bip : IItem
    {
        public int X { get; }
        public int Y { get; }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}