//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SearchingLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Announcing:UserList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Announcing()
        {
            this.Favorite_Announcing = new HashSet<Favorite_Announcing>();
            this.Selected_Announcing = new HashSet<Selected_Announcing>();
        }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string Name_City { get; set;}
        public int? Announcing_id { get; set; }
        public string Name_Announcing { get; set; }
        public Nullable<int> Phone_Announcing { get; set; }
        public System.DateTime? Date_Announcing { get; set; }
        public string Info_Announcing { get; set; }
        public int Categories_id { get; set; }
      //  public int User_id { get; set; }
      //  public int City_id { get; set; }
        public Nullable<int> Areas_id { get; set; }
    
        public virtual AreasOfCity AreasOfCity { get; set; }
        public virtual Categories Categories { get; set; }
      //  public virtual Cities Cities { get; set; }
        public virtual UserList UserList { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
      //  public virtual ICollection<Favorite_Announcing> Favorite_Announcing { get; set; }
       // [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Selected_Announcing> Selected_Announcing { get; set; }
    }
}
