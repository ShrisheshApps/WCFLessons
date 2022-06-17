using System.ServiceModel;

namespace ServiceLibrary
{
    [ServiceContract]
    interface ICalculate
    {
        [OperationContract]
        double Add(double number1, double number2);
        [OperationContract]
        double Subtract(double number1, double number2);
        [OperationContract]
        string GetMessage(string message);
    }
}
