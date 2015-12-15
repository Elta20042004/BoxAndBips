using System;

namespace Game.Rule
{
    public class DominanceRule : IRule                     //sedaet ochki
    {
        private void Apply(Box boxA, Box boxB)
        {
            if (boxB.State.Life >= boxA.State.Life)
            {
                var box = boxA;
                boxA = boxB;
                boxB = box;
            }

            int delta = Math.Min(boxB.State.Life, 10);
            boxA.State.Life += delta;
            boxB.State.Life -= delta;
        }

        public void Apply(Box box, World w)
        {
            ICell cell = w.GetCell(box.X, box.Y + 1);
            Box otherBox = cell as Box;
            if (otherBox != null)
            {
                Apply(box, otherBox);
            }

            cell = w.GetCell(box.X + 1, box.Y);
            otherBox = cell as Box;
            if (otherBox != null)
            {
                Apply(box, otherBox);
            }

        }
    }
}