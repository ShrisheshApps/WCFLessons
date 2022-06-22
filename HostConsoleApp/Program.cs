using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostConsoleApp
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ServiceLibrary.StudentService));
            host.Open();
            Console.WriteLine("Service started...");
            Console.WriteLine("Press any key to shut down the service...");
            Console.ReadKey();
            host.Close();
        }
    }
}
