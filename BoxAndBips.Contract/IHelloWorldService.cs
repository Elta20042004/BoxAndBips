using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace BoxAndBips.Contract
{
    [ServiceContract]
    public interface IHelloWorldService
    {
        [OperationContract]
        string Step(int k);



    }
}
