using System;
using System.Runtime.InteropServices;
using System.ServiceModel;
using BoxAndBips.Contract;
using BoxAndBips.Rule;

namespace BoxAndBips.Host
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class HelloWorldService : IHelloWorldService
    {
        private IWorld w;
        private Box box;
        public HelloWorldService()
        {
            w = new World(14, 15, new[] { new DominanceRule() });
            w.PutSpeedBip(1, 2, 0);
            w.PutSpeedBip(3, 2, 0);
            w.PutSpeedBip(0, 1, 0);
            w.PutLifeBip(1, 2, 5);
            w.PutLifeBip(2, 0, 5);

            box = new Box("box1", 50, w);
            box.X = 0;
            box.Y = 0;
            w.PutBox(box, 0, 0);

            Box robotBoxI = new Box("robot-I", 50, w);
            robotBoxI.X = 3;
            robotBoxI.Y = 3;
            w.PutBox(robotBoxI, 3, 3);

            Box robotBoxII = new Box("robot-II", 50, w);
            robotBoxII.X = 4;
            robotBoxII.Y = 4;
            w.PutBox(robotBoxII, 4, 4);

            Box robotBoxIII = new Box("robot-III", 50, w);
            robotBoxIII.X = 10;
            robotBoxIII.Y = 10;
            w.PutBox(robotBoxIII, 10, 10);

            RandomRobot randomBox = new RandomRobot(new[] { robotBoxI, robotBoxII, robotBoxIII });
        }
        

        public string SayHello(string name)
        {
            return name;
        }

        public string Step(int k)
        {
            if (k == 1)
            {
                box.StepUp();
            }
            else if (k == 2)
            {
                box.StepRight();
            }
            else if (k == 3)
            {
                box.StepDown();
            }
            else if (k==4)
            {
                box.StepLeft();
            }


            return w.ToString();
        }
    }
}