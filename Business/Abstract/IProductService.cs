using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);//list of product döndürür
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails();//details list döndürür
        IDataResult<Product> GetById(int productId);//Tek başına bir ürün döndürür
        IResult Add(Product product);
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);
        
    }

       
}
