using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SearchingLibrary
{
    [DataContract]
   public class TestClass:Messages
    {
        [DataMember]
        public bool Code { get; set; }

      public TestClass()
        {
            Code = false;
        }
    }
}
