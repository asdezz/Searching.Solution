using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main
{
  //Класс, в котором все функции над Объявлениями
   public class AnnouncingFunction
    {
        public static DataTable GetAnnouncing()
        {
            string queryString = "SELECT * FROM Announcing";
            DataTable table = SqlAccess.CreateCommandQuerySelect(queryString, "AnnouncingList");
            return table;
        }
    }
}
