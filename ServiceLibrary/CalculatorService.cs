namespace ServiceLibrary
{
    public class CalculatorService : ICalculate
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
    }
}
