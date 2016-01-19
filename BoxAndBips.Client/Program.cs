using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using BoxAndBips.Contract;

namespace BoxAndBips.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var myBinding = new BasicHttpBinding();  //Привязка для Web-служб
            var myEndpoint = new EndpointAddress("http://localhost:5555/hello");
            var myChannelFactory = new ChannelFactory<IHelloWorldService>(myBinding, myEndpoint);
            // Инициализирует новый экземпляр класса ChannelFactory<TChannel> 
            // с указанными привязкой и удаленным адресом.

            IHelloWorldService client = null;

            try
            {
                client = myChannelFactory.CreateChannel();
                //Создает канал заданного типа, связанный с заданным адресом конечной точки.

               

                while (true)
                {
                     ConsoleKeyInfo keyInfo = Console.ReadKey();
                
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.DownArrow:
                            client.Step(3);
                            break;
                        case ConsoleKey.RightArrow:
                            client.Step(2);
                            break;
                        case ConsoleKey.LeftArrow:
                            client.Step(4);
                            break;
                        case ConsoleKey.UpArrow:
                            client.Step(1);
                            break;
                    }
                
                }

                Console.Clear();

                ((ICommunicationObject)client).Close();
            }
            catch
            {
                if (client != null)
                {
                    ((ICommunicationObject)client).Abort(); //выкинуть
                }
            }
        }
    }
}
