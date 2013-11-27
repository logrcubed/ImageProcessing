using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace RestImageProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8000/Service";
            WebHttpBinding wb = new WebHttpBinding();
            wb.MaxBufferSize = 4194304;
            wb.MaxReceivedMessageSize = 4194304;
            wb.MaxBufferPoolSize = 4194304;

            ServiceHost host = new ServiceHost(typeof(ImageUploadService), new Uri(baseAddress));
            host.AddServiceEndpoint(typeof(IImageUpload), wb, "").Behaviors.Add(new WebHttpBehavior());
            //host.AddServiceEndpoint(typeof(IImageUpload), new WebHttpBinding(), "").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            Console.ReadKey(true);
        }
    }
}
