﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace Searching.UI.WinClient.Storage
{
    [Table]
    public class LUsers
    {
        [Column(IsDbGenerated =true,IsPrimaryKey =true)]
        public int User_id { get; set; }
        [Column]
        public string Mail { get; set; }
        [Column]
        public string FIO { get; set; }
        [Column]
        public byte Phone { get; set; }
        [Column]
        public string Gender_user { get; set; }
        [Column]
        public DateTime? Date_Bearthday { get; set; }
        [Column]
        public string Password { get; set; }
        [Column]
        public string Info { get; set; }
        [Column]
        public int? Country_id { get; set; }
        [Column]
        public byte Type_login { get; set; }
        [Column]
        public int? City_id { get; set; }

    }
}
