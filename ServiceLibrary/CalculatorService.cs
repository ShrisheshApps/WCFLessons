namespace ServiceLibrary
{
    public class CalculatorService : ICalculate, IConfidential
    {
        public double Add(double number1, double number2)
        {
            return number1 + number2;
        }
        public double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }
        public string GetMessage(string message)
        {
            return message;
        }

        public string PrivateMessage(string msg)
        {
            return "This is a confidential message code: " + msg;
        }
    }
}
