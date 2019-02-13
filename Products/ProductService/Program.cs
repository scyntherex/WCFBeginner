﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ProductService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFProductService)))
            {
                host.Open();
                Console.WriteLine("Server is open!");
                Console.WriteLine("<Press Enter to close server>");
                Console.ReadLine();
            }
        }
    }
}
