using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {

            //oracle ,sql server ,posgres,mongoDb ' den geliyormuş gibi biz bunları yazıcaz 
            _products = new List<Product> { 
            new Product{ProdcutID=1,CategoryID=1,ProductName="Bardak",UnitPrice=15,UnitsInStock= 15 },
            new Product{ProdcutID=2,CategoryID=1,ProductName="Kamera",UnitPrice=500,UnitsInStock= 3 },
            new Product{ProdcutID=3,CategoryID=2,ProductName="Telefon",UnitPrice=1500,UnitsInStock= 2 },
            new Product{ProdcutID=4,CategoryID=2,ProductName="Klavye",UnitPrice=150,UnitsInStock= 65 },
            new Product{ProdcutID=5,CategoryID=2,ProductName="Fare ",UnitPrice=85,UnitsInStock= 1 }
            }; 
        }
        public void Add(Product product)
        {
            _products.Add(product);
        }

        public void Delete(Product product)
        { //Lambda
            Product productToDelete = 
            //foreach (var p in _products)    
            //{
            //    if (product.ProdcutID==p.ProdcutID)
            //    {
            //        productToDelete = p;
            //    }


            //}

            productToDelete = _products.SingleOrDefault(p=>p.ProdcutID==product.ProdcutID);
                                    //bu kullandığımız yukardaki yorum satırı olan foreaach yerine kullanılır.



            _products.Remove(productToDelete);

        }

        public List<Product> GetAll()
        {
            return _products;
        }

        public List<Product> GetAllByCategory(int categoryId)
        {
          return _products.Where(p => p.CategoryID ==categoryId).ToList();

        }

        public List<Product> GetAllCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product) 
        {        //Gönderdiğim ürün Id 'sine sahib olan listedeki ürün ıd sini bul
             Product productToUpdate = _products.SingleOrDefault(p => p.ProdcutID == product.ProdcutID);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryID = product.CategoryID;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock; 
        }
    }
}
