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
    
    public partial class UserList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserList()
        {
            this.Announcing = new HashSet<Announcing>();
            this.Favorite_Announcing = new HashSet<Favorite_Announcing>();
            this.Selected_Announcing = new HashSet<Selected_Announcing>();
            this.Selected_User = new HashSet<Selected_User>();
            this.Selected_User1 = new HashSet<Selected_User>();
        }
    
        public int User_id { get; set; }
        public string Mail { get; set; }
        public string FIO { get; set; }
        public byte Phone { get; set; }
        public string Gender_user { get; set; }
        public System.DateTime Date_Bearthday { get; set; }
        public string Password { get; set; }
        public string Info { get; set; }
        public Nullable<int> Country_id { get; set; }
        public byte Type_login { get; set; }
        public Nullable<int> City_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Announcing> Announcing { get; set; }
        public virtual Cities Cities { get; set; }
        public virtual Country Country { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favorite_Announcing> Favorite_Announcing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Selected_Announcing> Selected_Announcing { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Selected_User> Selected_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Selected_User> Selected_User1 { get; set; }
    }
}