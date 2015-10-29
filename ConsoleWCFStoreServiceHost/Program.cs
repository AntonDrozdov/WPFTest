using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel;
using WCFStoreSErviceLib;


namespace ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "STORESERVER";
            /*
            Uri address = new Uri("http://127.0.0.1:5678/IStoreService");
            BasicHttpBinding binding = new BasicHttpBinding();
            Type contract = typeof(IStoreService);
            */
            ServiceHost service = new ServiceHost(typeof(StoreService));
            //host.AddServiceEndpoint(contract, binding, address);
            service.Open();

            foreach (System.ServiceModel.Description.ServiceEndpoint se in service.Description.Endpoints)
            {
                Console.WriteLine(se.Binding);
                Console.WriteLine(se.Address);
                Console.WriteLine(se.Contract.Name);
                
            }

            Console.WriteLine("Store service is ready...");
            Console.ReadKey();
            service.Close();
        }
    }
}
