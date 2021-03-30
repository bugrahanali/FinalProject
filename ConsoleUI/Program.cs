using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal());
                

            foreach (var product in productManager.GetAllByCategoryId(2)) //getby..... girebilirsin
            {
                Console.WriteLine(product.ProductName);
            }

        }
    }
}
