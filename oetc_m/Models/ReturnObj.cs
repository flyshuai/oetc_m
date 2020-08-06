using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace oetc_m.Models
{
     public class ReturnObj<T>
     {
         public int Code { get; set; }
         public T Data { get; set; }
         public string Msg { get; set; }
         public bool Success{ get; set; }
        public ReturnObj()
        {
            Code = 1;
            Msg = "Fail";
            Success = false;
        }
     }
}
