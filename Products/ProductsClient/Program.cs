using ProductInterfaces;
using ProductsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductsClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ChannelFactory<IWCFProductService> channelFactory =
                new ChannelFactory<IWCFProductService>("ProductServiceEndpoint");

            IWCFProductService proxy = channelFactory.CreateChannel();

            Console.WriteLine("Enter go to get data from server.");
            string input = Console.ReadLine();

            if (input == "go")
            {
                //calls server
                List<string> products = proxy.ListProducts();

                foreach (var p in products)
                {
                    Console.WriteLine(p);
                }

                Console.WriteLine("Enter product number to search:");
                string pnumber = Console.ReadLine();

                ProductData data = proxy.GetProduct(pnumber);

                Console.WriteLine(data.name);
                Console.WriteLine(data.Color);
                Console.WriteLine(data.ListPrice);

                Console.ReadLine();
            }

        }
    }
}
