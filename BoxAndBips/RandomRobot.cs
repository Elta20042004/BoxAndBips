using System;
using System.Collections.Generic;

namespace BoxAndBips
{
    public class RandomRobot : IRobot
    {
        private readonly IEnumerable<Box> _boxes;
        private readonly Random _random;

        public RandomRobot(IEnumerable<Box> boxes)
        {
            _boxes = boxes;
            _random = new Random();
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
            
            while (steps.Count < 4)
            {
                int k = _random.Next(4);

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
                        steps.Add(Step.Right); break;
                    case 3:
                        if (box.StepUp())
                        {
                            return;
                        }
                        steps.Add(Step.Up); break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}