using Searching.DAL.Main.Helper;
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
            string query = "SELECT a.Info_Announcing, a.Date_Announcing, a.User_id, a.Announcing_id, a.Name_Announcing, u.Name,u.LastName ,ROW_NUMBER() OVER(ORDER BY  a.Announcing_id) AS Row_id FROM Announcing a JOIN Cities c ON c.City_id = a.City_id JOIN[UserList] u ON  u.[User_id] = a.[User_id] WHERE  a.City_id = ISNULL(@City_id, a.City_id) AND (@Areas_id is NULL or a.Areas_id = @Areas_id) AND a.Categories_id = ISNULL(@Category_id, a.Categories_id) AND u.Gender_user = ISNULL(@Gender_user, u.Gender_user) AND u.Date_Bearthday BETWEEN ISNULL(@MinDateBearthday, u.Date_Bearthday) AND ISNULL(@MaxDateBearthday, u.Date_Bearthday) AND a.Date_Announcing >= ISNULL(@Date_Announcing, a.Date_Announcing)";
            query = QueryPaging.CreareObjectList(query);
            query = QueryPaging.CreatePaging(query);
            SqlCommand command = new SqlCommand(query, connect);
            command = DBValueCheking.AddWithCheckValue(command, "@Category_id", filter.Category_id);
            command = DBValueCheking.AddWithCheckValue(command, "@City_id", filter.City_id);
            command = DBValueCheking.AddWithCheckValue(command, "@Areas_id", filter.Areas_id);
            command = DBValueCheking.AddWithCheckValue(command, "@Gender_user", filter.Gender_user);
            command = DBValueCheking.AddWithCheckValue(command, "@MinDateBearthday", filter.MinDateBirthday);
            command = DBValueCheking.AddWithCheckValue(command, "@MaxDateBearthday", filter.MaxDateBirthday);
            command = DBValueCheking.AddWithCheckValue(command,"@Date_Announcing",filter.DateAnnouncing);
            command = DBValueCheking.AddValue(command, "@nPage", filter.nPage);
            command = DBValueCheking.AddValue(command, "@sizePage", filter.sizePage);
            //try
            //{
            //    connect.Open();
            //    command.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    Logger.CreateLog(ex);
            //    throw ex;
            //}
            //finally
            //{
            //    connect.Close();
            //}
            var table = SqlAccess.CreateQuery(command,"GetAnnouncingWithFilter");
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
