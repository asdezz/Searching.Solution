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
    using System.Runtime.Serialization;
    [DataContract]
    public partial class Selected_Announcing
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public int Announcing_id { get; set; }
        [DataMember]
        public int User_id { get; set; }
       // public int User_id { get; set; }
    
       // public virtual Announcing Announcing { get; set; }
       // public virtual UserList UserList { get; set; }
    }
}
