using Core.Utilities.Results;
using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
   public interface ICategoryService
    {
        //Category ile ilgili dış dünyaya neyi göstermek istiyorsam onlar.
       IDataResult<List<Category>>GetAll();
       IDataResult<Category> GetById(int categoryId);


    }
}
