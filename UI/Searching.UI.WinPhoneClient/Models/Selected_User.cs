using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinPhoneClient.Models
{
   public class Selected_User
    {
        public int id { get; set; }
        public int User_id { get; set; }
        public int Selected_user1 { get; set; }

        public virtual UserList UserList { get; set; }
        public virtual UserList UserList1 { get; set; }
    }
}
