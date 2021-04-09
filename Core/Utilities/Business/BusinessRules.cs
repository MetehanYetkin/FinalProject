using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)//Params türünde virgül ile ayrılarak istediğimiz kadar parametre isteyebiliriz.
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)//BAŞARISIZ OLANI BUSİNESSE GÖNDERİYORZ.
                {
                    return logic;
                }
            }
            return null;//Başarılı ise birşey döndürme
        }
    }
}
