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
    //Класс, в котором все функции, которые связанные с подписчиками 
   public static class FollowersFunction
    {
        public static void AddSelectedUser(Selected_User user)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "INSERT INTO Selected_User (User_id, Selected_user) VALUES(@User_id, @Selected_user)";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command = DBValueCheking.AddValue(command, "@User_id", user.User_id);
            command = DBValueCheking.AddValue(command, "@Selected_user", user.Selected_user);
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.CreateLog(ex);
                throw ex;
            }
            finally
            {
                connect.Close();
            }
        }
        public static void DeleteSelectedUser(Selected_User user)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "DELETE FROM Selected_User WHERE User_id = @User_id AND Selected_user = @Selected_user";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command = DBValueCheking.AddValue(command, "@User_id", user.User_id);
            command = DBValueCheking.AddValue(command, "@Selected_user", user.Selected_user);
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.CreateLog(ex);
                throw ex;
            }
            finally
            {
                connect.Close();
            }
        }
        public static DataTable FollowersList(int user_id)
        {

            string connectString = SqlAccess.GetConnectionString();
            string queryString = "";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.CreateLog(ex);
                throw ex;
            }
            finally
            {
                connect.Close();
            }
            var table = SqlAccess.CreateQuery(command, "FollowersList");
            return table;
        }
    }
}
