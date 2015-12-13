using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.UI.WinClient.Storage
{
   public  class UserDataContext:DataContext
    {
        public static string DBConnectionString = @"isostore:/Databases.sdf";
        public UserDataContext(string connectrionString):base(connectrionString)
        {
            
        }
        public Table<LUsers> User
        {
            get { return this.GetTable<LUsers>(); }
        }
    }
}
