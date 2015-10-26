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
            string query = "SELECT a.Announcing_id, a.Name_Announcing, c.City_name FROM Announcing a JOIN Cities c ON c.City_id = a.City_id JOIN[UserList] u ON  u.[User_id] = a.[User_id] WHERE  a.City_id = ISNULL(@City_id, a.City_id) AND a.Areas_id = ISNULL(@Areas_id, a.Areas_id) AND a.Categories_id = ISNULL(@Categories_id, a.Categories_id) AND u.Gender_user = ISNULL(@Gender_user, u.Gender_user) AND u.Date_Bearthday BETWEEN ISNULL(@MinDateBearthday, u.Date_Bearthday) AND ISNULL(@MaxDateBearthday, u.Date_Bearthday) AND a.Date_Announcing >= ISNULL(@DateAnnouncing, a.Date_Announcing)";
             SqlCommand command = new SqlCommand(query, connect);
            command.Parameters.Add("@City_id",SqlDbType.Int);
            command.Parameters.Add("@Areas_id",SqlDbType.Int);
            command.Parameters.Add("@Gender_user", SqlDbType.Char);
            command.Parameters.Add("@MinDate_Bearthday",SqlDbType.Date);
            command.Parameters.Add("@MaxDate_Bearthday", SqlDbType.Date);
            command.Parameters.Add("@Date_Announcing", SqlDbType.Date);
            foreach(DataRow row in table.Rows)
            {
                command.Parameters.Add("@Category_id", SqlDbType.Int);
                command.Parameters["@Category_id"].Value =int.Parse(row["Category_id"].ToString());
                command.Parameters["@City_id"].Value = int.Parse(row["City_id"].ToString());
                command.Parameters["@Areas_id"].Value = int.Parse(row["Areas_id"].ToString());
                command.Parameters["@Gender_user"].Value = row["Gender_user"].ToString();
                command.Parameters["@MinDateBearthday"].Value = DateTime.Parse(row["MinDateBearthday"].ToString());
                command.Parameters["@MaxDateNearthday"].Value = DateTime.Parse(row["MaxDateBearthday"].ToString());
                command.Parameters["@DateAnnouncing"].Value = DateTime.Parse(row["DateAnnouncing"].ToString());
            }
            try
            {
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            table = SqlAccess.CreateQuery(command,"GetAnnouncingWithFilter");
            return table;
        }

        public static DataTable GetAnnouncingFromCity(int City_id)
        {
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            string queryString = "SELECT * FROM Announcing WHERE City_id =@City_id";
            SqlCommand command = new SqlCommand(queryString, connect);
            command.Parameters.Add("@City_id", SqlDbType.Int);
            command.Parameters["@City_id"].Value=City_id;
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

        public static DataTable GetAnnouncingForCategory(int Category_id)
        {
            
            string connectString = SqlAccess.GetConnectionString();
            string queryString = @"SELECT * FROM Announcing WHERE Categories_id = @Category_id";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command.Parameters.Add("@Category_id", SqlDbType.Int);
            command.Parameters["@Category_id"].Value = Category_id;

            try
            {
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                connect.Close();
            }
            
            DataTable table = SqlAccess.CreateQuery(command, "AnnouncingForCategory");
            return table;
        }
    }
}
