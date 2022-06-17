using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace HostConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri baseAddress = new Uri("http://localhost:8001/");
            ServiceHost host = new ServiceHost(typeof(ServiceLibrary.CalculatorService), baseAddress);
            host.AddServiceEndpoint(typeof(ServiceLibrary.ICalculate), new BasicHttpBinding(), baseAddress);

            ServiceMetadataBehavior smdb = new ServiceMetadataBehavior();
            smdb.HttpGetEnabled = true;
            host.Description.Behaviors.Add(smdb);
            //host.Description.Endpoints.Add();
            host.Open();
            Console.WriteLine("Service started...");
            Console.WriteLine("Press ENTER to stop service...");
            Console.ReadKey();
            host.Close();
        }
    }
}
