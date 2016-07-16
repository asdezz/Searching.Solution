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
  public  static  class AnnouncingFilter
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
            string query = "SELECT Announcing.Announcing_id, Announcing.Name_Announcing, Announcing.Date_Announcing, Announcing.Info_Announcing, u.[User_id], u.[Name], u.LastName FROM  Announcing JOIN[UserList] u ON u.[User_id] = Announcing.[User_id]";
            SqlCommand command = new SqlCommand(query, connect);
            command = DBValueCheking.CheckValue(command, "@Category_id", filter.Category_id);
            command = DBValueCheking.CheckValue(command, "@City_id", filter.City_id);
            command = DBValueCheking.CheckValue(command, "@Areas_id", filter.Areas_id);
            command = DBValueCheking.CheckValue(command, "@Gender_user", filter.Gender_user);
            command = DBValueCheking.CheckValue(command, "@MinDateBearthday", filter.MinDateBirthday);
            command = DBValueCheking.CheckValue(command, "@MaxDateBearthday", filter.MaxDateBirthday);
            command = DBValueCheking.CheckValue(command,"@Date_Announcing",filter.DateAnnouncing);
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

        public static DataTable GetAnnouncingFull(int announcing_id)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "SELECT a.Announcing_id, a.Name_Announcing, a.Phone_Announcing, a.Date_Announcing,ul.Name,ul.LastName,c.City_name, a.Info_Announcing FROM Announcing a JOIN UserList ul ON ul.[User_id] = a.[User_id] JOIN Cities c ON c.City_id = a.City_id WHERE a.Announcing_id= @Announcing_id";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command = DBValueCheking.AddValue(command, "@Announcing_id", announcing_id);
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
            DataTable table = SqlAccess.CreateQuery(command, "GetAnnouncingAll");
            return table;
        }
    }
}
