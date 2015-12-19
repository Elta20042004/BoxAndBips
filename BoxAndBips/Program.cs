using System;
using BoxAndBips.Rule;

namespace BoxAndBips
{
    class Program
    {
        static void Main(string[] args)
        {

            IWorld w = new World(14, 15,new[] {new DominanceRule()});
            w.PutSpeedBip(1, 2, 0);
            w.PutSpeedBip(3, 2, 0);
            w.PutSpeedBip(0, 1, 0);
            w.PutLifeBip(1, 2, 5);
            w.PutLifeBip(2, 0, 5);

            var box = new Box("box1", 50, w);
            box.X = 0;
            box.Y = 0;
            w.PutBox(box, 0, 0);

            Box robotBoxI = new Box("robot-I", 50, w);
            robotBoxI.X = 3;
            robotBoxI.Y = 3;
            w.PutBox(robotBoxI,3,3);

            Box robotBoxII = new Box("robot-II", 50, w);
            robotBoxII.X = 4;
            robotBoxII.Y = 4;
            w.PutBox(robotBoxII, 4, 4);

            Box robotBoxIII = new Box("robot-III", 50, w);
            robotBoxIII.X = 10;
            robotBoxIII.Y = 10;
            w.PutBox(robotBoxIII, 10, 10);

            RandomRobot randomBox = new RandomRobot(new[] { robotBoxI , robotBoxII , robotBoxIII });
         

            Console.WriteLine(w.ToString());
            Console.WriteLine(box.State.Life);
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        box.StepDown();
                        break;
                    case ConsoleKey.RightArrow:
                        box.StepRight();
                        break;
                    case ConsoleKey.LeftArrow:
                        box.StepLeft();
                        break;
                    case ConsoleKey.UpArrow:
                        box.StepUp();
                        break;
                }
                randomBox.DoStep();
                w.ApplyRules();
                Console.Clear();
                Console.WriteLine(w);

                Console.WriteLine("{0} {1}",box.Name,box.State.Life);
                Console.WriteLine("{0} {1}", robotBoxI.Name, robotBoxI.State.Life);
                Console.WriteLine("{0} {1}", robotBoxII.Name, robotBoxII.State.Life);
                Console.WriteLine("{0} {1}", robotBoxIII.Name, robotBoxIII.State.Life);
            }
        }
    }
}
