using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main
{
    // Класс, в котором функции фильтра Объявлений. 
  public  class AnnouncingFilter
    {
        public static DataTable GetCategories()
        {
            string queryString = "SELECT * FROM Categories";
            DataTable table = SqlAccess.CreateCommandQuerySelect(queryString, "CategoriesList");
            return table;
        }
        //int? country,int? city,int? areas,char? Gender_user,int? Date_Bearthday
        public static DataTable GetAnnouncingFilter(DataTable table)
        {
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            string query = "";
            SqlCommand command = new SqlCommand(query, connect);
            if (table.Select("Country_id") !=null)
             {
                query = "SELECT fa.Announcing_id, fa.Name_Announcing, fa.Phone_Announcing,fa.Date_Announcing, fa.Info_Announcing, fa.[User_id], fa.Areas_id,fa.City_id, fa.Categories_id, c.Name_country, c2.City_name,aoc.Areas_name FROM  Announcing fa JOIN[Searching].[dbo].[User] a JOIN Country c ON c.Country_id = @Country_id";
                
                command.Parameters.Add("@Country_id",SqlDbType.Int);
                command.Parameters["@Country_id"].Value = table.Select("Country_id");
             }
            if (table.Select("City_id") !=null)
             {
                query = "SELECT fa.Announcing_id, fa.Name_Announcing, fa.Phone_Announcing,fa.Date_Announcing, fa.Info_Announcing, fa.[User_id], fa.Areas_id,fa.City_id, fa.Categories_id, c.Name_country, c2.City_name,aoc.Areas_name FROM  Announcing fa JOIN[Searching].[dbo].[User] a JOIN Country c ON c.Country_id = @Country_id,fa.City_id=@City_id";
                command.Parameters.Add("@City_id",SqlDbType.Int);
                command.Parameters["@City_id"].Value = table.Select("City_id");
             }

            
            return table;
        }

        public static DataTable GetAnnouncingFromCity(int City_id)
        {
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            string queryString = "SELECT * FROM Announcing WHERE City_id =@City_id";
            SqlCommand command = new SqlCommand(queryString, connect);
            command.ExecuteNonQuery();
            DataTable table = SqlAccess.CreateQuery(command, "AnnouncingListFromCity");
            return table;
        }

        public static DataTable GetAnnouncingForAreasOfCity(int AreasOfCity_id)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "SELECT * FROM Announcing WHERE Areas_id = @AreasOfCity_id";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command.Parameters.Add("@AreasOfCity_id", SqlDbType.Int);
            command.Parameters["@AreasOfCity_id"].Value = AreasOfCity_id;
            command.ExecuteNonQuery();
            DataTable table = SqlAccess.CreateQuery(command, "AnnouncingforAreasOfCity");
            return table;
        }
    }
}
