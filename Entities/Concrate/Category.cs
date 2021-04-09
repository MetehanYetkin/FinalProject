
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrate
{
    //Cıplak class kalamasın

   public class Category:IEntitiy

    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
