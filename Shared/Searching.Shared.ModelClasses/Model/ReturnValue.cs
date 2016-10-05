using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SearchingLibrary
{
    [DataContract]
   public  class ReturnValue
    {
        public ReturnValue()
        {
            Code = false;
        }
        [DataMember]
        public bool Code { get; set; }
        [DataMember]
        public int Session_id { get; set; }
        [DataMember]
        public string Message { get; set; }
    }
}
