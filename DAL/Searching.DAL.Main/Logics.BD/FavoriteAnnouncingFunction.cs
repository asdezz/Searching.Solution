using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main
{
    //Класс, в котором все функции над Выбранными Объявлениями
  public  class FavoriteAnnouncingFunction
    {
        public static DataTable GetFavoriteAnnouncing(int User_id)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "SELECT a.Announcing_id, a.Name_Announcing, a.Phone_Announcing, a.Areas_id, a.Date_Announcing, a.Info_Announcing, a.Categories_id FROM   Favorite_Announcing fa JOIN Announcing a ON  a.Announcing_id = fa.Announcing_id WHERE fa.[User_id] = @User_id";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command.Parameters.Add("@User_id", SqlDbType.Int);
            command.Parameters["@User_id"].Value = User_id;
            command.ExecuteNonQuery();
            DataTable table = SqlAccess.CreateQuery(command, "Favorite_Announcing");
            return table;
        }
    }
}
