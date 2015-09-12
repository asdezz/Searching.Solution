using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinPhoneClient.Models
{
   public class AreasOfCity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AreasOfCity()
        {
            this.Announcing = new HashSet<Announcing>();
        }

        public int Areas_id { get; set; }
        public string Areas_name { get; set; }
        public int City_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Announcing> Announcing { get; set; }
        public virtual Cities Cities { get; set; }
    }

}
