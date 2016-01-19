using System;

namespace BoxAndBips
{
    public abstract class Bip : IItem
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}