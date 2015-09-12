using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinPhoneClient.Models
{
   public class Selected_Announcing
    {
        public int id { get; set; }
        public int Announcing_id { get; set; }
        public int User_id { get; set; }

        public virtual Announcing Announcing { get; set; }
        public virtual UserList UserList { get; set; }
    }
}
