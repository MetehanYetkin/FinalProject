using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess//CORE KATMANIDĞİER KATMANLARI REFERANS ALMAZ.
{
    //Generic constraint
    //class : referans tip olabilir.
    //new () : new'lenebilir olmalıdır.(IEntitiy koyamazız bu yüzden.)
   public interface IEntitiyRepository<T> where T:class,IEntitiy,new() //T bir refeans tip olmalı ve ya IEntitiy ya da IEntitiyden referans bir tip olabilir.

    {

        List<T> GetAll(Expression<Func<T,bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter ); //T döndüren Get operasyonu
        void Add(T entitiy);
        void Update(T entitiy);
        void Delete(T entitiy);
        
    }
}
