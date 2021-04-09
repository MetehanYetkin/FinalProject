using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public interface IDataResult<T>:IResult//IResult var aynı zamanda bi de hangi tiple döndüreceğini veren var
    {
        T Data { get; }

    }
}

