using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinPhoneClient.Models
{
  public  class Announcing
    {
        public Announcing()
        {
            this.Favorite_Announcing = new HashSet<Favorite_Announcing>();
            this.Selected_Announcing = new HashSet<Selected_Announcing>();
        }
        public int Announcing_id { get; set; }
        public string Name_Announcing { get; set; }
        public Nullable<int> Phone_Announcing { get; set; }
        public System.DateTime Date_Announcing { get; set; }
        public string Info_Announcing { get; set; }
        public int Categories_id { get; set; }
        public int User_id { get; set; }
        public int City_id { get; set; }
        public Nullable<int> Areas_id { get; set; }

        public virtual AreasOfCity AreasOfCity { get; set; }
        public virtual Categories Categories { get; set; }
        public virtual Cities Cities { get; set; }
        public virtual UserList UserList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorite_Announcing> Favorite_Announcing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Selected_Announcing> Selected_Announcing { get; set; }
    }
}
