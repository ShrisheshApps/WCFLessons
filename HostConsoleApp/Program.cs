using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace HostConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ServiceLibrary.CalculatorService));
            host.Open();
            Console.WriteLine("Service started...");
            Console.WriteLine("Press ENTER to stop service...");
            Console.ReadKey();
            host.Close();
        }
    }
}
