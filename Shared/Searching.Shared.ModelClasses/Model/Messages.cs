using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingLibrary
{
   public class Messages:Announcing
    {
        public Messages()
        {
            Status_id = 0;
        }

       public int? Session_id { get; set; }
       public int Sender_id { get; set; }
       public int? Recipient_id { get; set; }
       public int Status_id { get; set; }
       public int Type_id { get; set; } 
       public DateTime Date_Message { get; set; }
       public string Message { get; set; }
      // public int User_id { get; set; }
    }
}
