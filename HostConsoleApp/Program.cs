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
            Uri baseAddress = new Uri("http://localhost:8001/");
            Uri baseAddress2 = new Uri("net.tcp://localhost:8002/");
            Uri[] bas = new Uri[] { baseAddress, baseAddress2 };
            ServiceHost host = new ServiceHost(typeof(ServiceLibrary.CalculatorService), bas);
       
            //Metadata exchange behavior added to host
            ServiceMetadataBehavior smdb = new ServiceMetadataBehavior();
            host.Description.Behaviors.Add(smdb);
            //Metadata exchange endpoint1
            Binding binding_http = MetadataExchangeBindings.CreateMexHttpBinding();
            host.AddServiceEndpoint(typeof(IMetadataExchange), binding_http, "Mex");
            //Metadata exchange endpoint2
            Binding binding_tcp = MetadataExchangeBindings.CreateMexTcpBinding();
            host.AddServiceEndpoint(typeof(IMetadataExchange), binding_tcp,"Mex");
            //Service endpoints
            host.AddServiceEndpoint(typeof(ServiceLibrary.ICalculate), new BasicHttpBinding(), baseAddress);
            host.AddServiceEndpoint(typeof(ServiceLibrary.ICalculate), new NetTcpBinding(), baseAddress2);
            //open the service after defining endpoints
            host.Open();
            Console.WriteLine("Service started...");
            Console.WriteLine("Press ENTER to stop service...");
            Console.ReadKey();
            host.Close();
        }
    }
}
