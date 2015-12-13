using System;
using System.Collections.Generic;
using System.Linq;

namespace Game
{
    public class RandomRobot : IRobot
    {
        private readonly IEnumerable<Box> _boxes;

        public RandomRobot(IEnumerable<Box> boxes)
        {
            _boxes = boxes;
        }

        public void DoStep()
        {
            foreach (var box in _boxes)
            {
                DoStep(box);
            }
        }

        private void DoStep(Box box)
        {
            HashSet<Step> steps = new HashSet<Step>();
            Random random = new Random();
            while (steps.Count < 4)
            {
                int k = random.Next(0, 3);

                switch (k)
                {
                    case 0:
                        if (box.StepDown())
                        {
                            return;
                        }
                        steps.Add(Step.Down);break;
                    case 1:
                        if (box.StepLeft())
                        {
                            return;
                        }
                        steps.Add(Step.Left); break;
                    case 2:
                        if (box.StepRight())
                        {
                            return;
                        }
                        steps.Add(Step.Down); break;
                    case 3:
                        if (box.StepUp())
                        {
                            return;
                        }
                        steps.Add(Step.Down); break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}