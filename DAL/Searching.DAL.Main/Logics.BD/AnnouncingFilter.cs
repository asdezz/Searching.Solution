using SearchingLibrary;
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
        public static DataTable GetAnnouncingFilter(AnnFilter filter)
        {
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            string query = "SELECT a.Announcing_id, a.Name_Announcing, c.City_name FROM Announcing a JOIN Cities c ON c.City_id = a.City_id JOIN[UserList] u ON  u.[User_id] = a.[User_id] WHERE  a.City_id = ISNULL(@City_id, a.City_id) AND a.Areas_id = ISNULL(@Areas_id, a.Areas_id) AND a.Categories_id = ISNULL(@Category_id, a.Categories_id) AND u.Gender_user = ISNULL(@Gender_user, u.Gender_user) AND u.Date_Bearthday BETWEEN ISNULL(@MinDateBearthday, u.Date_Bearthday) AND ISNULL(@MaxDateBearthday, u.Date_Bearthday) AND a.Date_Announcing >= ISNULL(@Date_Announcing, a.Date_Announcing)";
            SqlCommand command = new SqlCommand(query, connect);
            command.Parameters.Add("@City_id",SqlDbType.Int);
            command.Parameters.Add("@Areas_id",SqlDbType.Int);
            command.Parameters.Add("@Gender_user", SqlDbType.Char);
            command.Parameters.Add("@MinDateBearthday",SqlDbType.Date);
            command.Parameters.Add("@MaxDateBearthday", SqlDbType.Date);
            command.Parameters.Add("@Date_Announcing", SqlDbType.Date);
            //command.Parameters.Add("@Category_id", SqlDbType.Int);
            if (filter.Category_id == null)
            {
                command.Parameters.AddWithValue("@Category_id", DBNull.Value);
            }
            else { command.Parameters["@Category_id"].Value = filter.Category_id; }
            command.Parameters["@City_id"].Value = filter.City_id;
            command.Parameters["@Areas_id"].Value = filter.Areas_id;
            command.Parameters["@Gender_user"].Value = filter.Gender_user;
            command.Parameters["@MinDateBearthday"].Value = filter.MinDateBirthday;
            command.Parameters["@MaxDateBearthday"].Value = filter.MaxDateBirthday;
            command.Parameters["@Date_Announcing"].Value = filter.MinDateAnnouncing;

            try
            {
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Logger.CreateLog(ex);
                throw ex;
            }
            finally
            {
                connect.Close();
            }
            var table = SqlAccess.CreateQuery(command,"GetAnnouncingWithFilter");
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
