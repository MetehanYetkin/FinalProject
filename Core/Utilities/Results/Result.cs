using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
       

        public Result(bool success, string message):this (success)//2 parametere gönderen birisi için this(succes) ile tek parametreli olanı çalıştır.
        {
            Message = message;
           

        }
        public Result(bool success)
        {
           
            Success = success;

        }
        //get constr içinde set olaiblir
        public bool Success { get; }

        public string Message { get; }


    }
}
