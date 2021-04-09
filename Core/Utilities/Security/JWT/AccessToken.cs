using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
   public class AccessToken
    {
        public string Token { get; set; }//json wep token değeriimiz
        public DateTime Expiration { get; set; }//token bitiş zamanı 
    }
}
