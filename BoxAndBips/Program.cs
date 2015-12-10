using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Game;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            World w = new World(14, 15);
            w.PutSpeedBip(1, 2, 0);
            w.PutSpeedBip(3, 2, 0);
            w.PutSpeedBip(0, 1, 0);
            w.PutLifeBip(1, 2, 5);
            w.PutLifeBip(2, 0, 5);

            var box = new Box("box1", 10, w);
            box.X = 0;
            box.Y = 0;

            w.PutBox(box, 0, 0);

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
                Console.Clear();
                Console.WriteLine(w);
                Console.WriteLine(box.State.Life);
            }
        }
    }
}
