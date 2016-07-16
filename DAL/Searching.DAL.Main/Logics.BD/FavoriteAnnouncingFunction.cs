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
    //Класс, в котором все функции над Выбранными Объявлениями
  public static  class FavoriteAnnouncingFunction
    {

        public static DataTable CheckRecording(Favorite_Announcing ann)
        { 
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "SELECT* from Favorite_Announcing f where f.Announcing_id = @ann_id AND f.User_id = @user_id";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            DBValueCheking.AddValue(command, "@ann_id", ann.Announcing_id);
            DBValueCheking.AddValue(command, "@user_id", ann.User_id);
            //try {
            //    connect.Open(); 
            //    command.ExecuteNonQuery();
                
            //}catch(Exception ex)
            //{
                
            //    Logger.CreateLog(ex);
            //    throw ex;
            //}
            //finally
            //{
            //    connect.Close();
            //}
            var table = SqlAccess.CreateQuery(command, "CheckRecording");
            return table;
        } 
        public static DataTable GetFavoriteAnnouncing(int User_id)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "SELECT a.Announcing_id, a.Name_Announcing, a.Phone_Announcing, a.Areas_id, a.Date_Announcing, a.Info_Announcing, a.Categories_id FROM   Favorite_Announcing fa JOIN Announcing a ON  a.Announcing_id = fa.Announcing_id WHERE fa.[User_id] = @User_id";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command.Parameters.Add("@User_id", SqlDbType.Int);
            command.Parameters["@User_id"].Value = User_id;
           // command.ExecuteNonQuery();
            DataTable table = SqlAccess.CreateQuery(command, "Favorite_Announcing");
            return table;
        }
        public static ReturnValue AddToFavorite(Favorite_Announcing ann)
        {
            ReturnValue result = new ReturnValue();
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "INSERT INTO Favorite_Announcing(Announcing_id,User_id) VALUES(@Announcing_id, @User_id);";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command = DBValueCheking.AddValue(command, "@Announcing_id", ann.Announcing_id);
            command = DBValueCheking.AddValue(command, "@User_id", ann.User_id);
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
                result.Code = true;
                result.Message = "Операция прошла успешно!";
            }
            catch (Exception ex)
            {
                Logger.CreateLog(ex);
                result.Code = false;
                result.Message = ex.Message;
                //throw ex;
            }
            finally
            {
                connect.Close();
                
            }
            return result;
        }
        public static void DeleteFavorite(Favorite_Announcing ann)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "DELETE FROM Favorite_Announcing WHERE Announcing_id = @Announcing_id AND User_id = @User_id";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command = DBValueCheking.AddValue(command, "@Announcing_id", ann.Announcing_id);
            command = DBValueCheking.AddValue(command, "@User_id", ann.User_id);
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
    }
}
