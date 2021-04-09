using Core.DataAccess;
using Entities.Concrate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{// interface metodları defoult publictir

   public interface IProductDal:IEntitiyRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();

    }
}
//Code Refactoring