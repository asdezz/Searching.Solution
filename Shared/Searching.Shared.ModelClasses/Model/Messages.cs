using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SearchingLibrary
{
    [DataContract]
   public class Messages
    {
        public Messages()
        {
            Status_id = 0;
        }
        [DataMember]
       public int? Session_id { get; set; }
        [DataMember]
        public int? User_id { get; set; }
        [DataMember]
        public int Sender_id { get; set; }
        [DataMember]
        public int? Recipient_id { get; set; }
        [DataMember]
        public int Status_id { get; set; }
        [DataMember]
        public int Type_id { get; set; }
        [DataMember]
        public DateTime Date_Message { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public int Announcing_id { get; set; }
      // public int User_id { get; set; }
        public int Categories_id { get; set; }
    }
}
