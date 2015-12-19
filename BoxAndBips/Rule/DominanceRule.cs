using System;
using BoxAndBips.State;

namespace BoxAndBips.Rule
{
    public class DominanceRule : IRule                     //sedaet ochki
    {
        public void Apply(Box box, IWorld w)
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

            cell = w.GetCell(box.X + 1, box.Y + 1);
            otherBox = cell as Box;
            if (otherBox != null)
            {
                Apply(box, otherBox);
            }

            cell = w.GetCell(box.X + 1, box.Y-1);
            otherBox = cell as Box;
            if (otherBox != null)
            {
                Apply(box, otherBox);
            }

        }

        private void Apply(Box boxA, Box boxB)
        {
            if (boxB.State.Life >= boxA.State.Life)
            {
                var box = boxA;
                boxA = boxB;
                boxB = box;
            }

            if (!(boxB.State is DeadBoxState))
            {
                int delta = Math.Min(boxB.State.Life, 10);
                boxA.State.Life += delta;
                boxB.State.Life -= delta;
            }
        }
    }
}