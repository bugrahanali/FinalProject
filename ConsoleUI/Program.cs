using Business.Concrete;
using System;
using DataAccess.Concrete.InMemory;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework.NewFolder;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            productTest();
            //CategoryTest();




        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void productTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());


            foreach (var product in productManager.GetpdoructDetails())  
            {
                Console.WriteLine(product.ProductName +  "/" + product.CategoryName);
            }
        }
    }
}
