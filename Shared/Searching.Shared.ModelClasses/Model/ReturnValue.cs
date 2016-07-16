using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingLibrary
{
   public  class ReturnValue:Messages
    {
        public ReturnValue()
        {
            Code = false;
        }
        public bool Code { get; set; }
    }
}
