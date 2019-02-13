using ProductInterfaces;
using ProductsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WCFProductService" in both code and config file together.
    public class WCFProductService : IWCFProductService
    {
        public ProductData GetProduct(string productNumber)
        {
            ProductData productData = null;
            try
            {
                using (adventureworksEntities database = new adventureworksEntities())
                {
                    product matchingProduct = database.products.First((p) =>
                        p.ProductNumber == productNumber);

                   /* var query = from pros in database.products
                                where pros.ProductNumber == productNumber
                                select pros;

                    product pp = query.FirstOrDefault();*/

                    productData = new ProductData();
                    productData.name = matchingProduct.Name;
                    productData.productNum = matchingProduct.ProductNumber;
                    productData.Color = matchingProduct.Color;
                    productData.ListPrice = matchingProduct.ListPrice;
                }
            }
            catch
            {

            }
            return productData;
        }

        public List<string> ListProducts()
        {
            Console.WriteLine("ListProducts called by client.");

            List<string> productList = new List<string>();
            try
            {
                using(adventureworksEntities database = new adventureworksEntities())
                {
                   /* var products = from product in database.products
                                   select product.ProductNumber;

                    productList = products.ToList();*/

                    foreach (var p in database.products)
                    {
                        productList.Add(p.ProductNumber);
                    }
                }
            }
            catch
            {

            }
            return productList;
        }
    }
}
