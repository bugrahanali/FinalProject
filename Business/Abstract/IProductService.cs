using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        
        void Delete(Product product);
        void Update(Product product);
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min,decimal max);

        IDataResult<List<ProductDetailDto>> GetProductDetails();
        IResult Add(Product product);
    }
}
