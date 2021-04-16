using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constents_sabitler_;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{


    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        

        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;



        }
        [CacheRemoveAspect("IProductService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            IResult result = BusinessRules.Run(ChechkIfproductCountofCategoryCorrect(product.CategoryId),
                ChechkIfProductNameExist(product.ProductName));
            if (result !=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);

                
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        //[PerformanceAspect(5)]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        { 
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p=>p.CategoryId==id));
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice<= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public void Update(Product product)
        {
            _productDal.Update(product);
        }










        private IResult ChechkIfproductCountofCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();       
        }


        private IResult ChechkIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyexist);
            }
            
                 return new SuccessResult();
        
        }

      
        

    }
}
   