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
  //Класс, в котором все функции над Объявлениями
   public  static class AnnouncingFunction
    {
        public static DataTable GetAnnouncing()
        {
            string queryString = "SELECT * FROM Announcing";
            DataTable table = SqlAccess.CreateCommandQuerySelect(queryString, "AnnouncingList");
            return table;
        }
        public static void AddAnnoucing(Announcing ann)
        {
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            string query = "INSERT INTO UserList (Name_Announcing, Phone_Announcing,Date_Announcing, Info_Announcing, Categories_id, User_id,City_id, Areas_id) VALUES(@Name_Announcing, @Phone_Announcing, @Date_Announcing, @Info_Announcing, @Categories_id, @User_id, @City_id, ISNULL(@Areas_id, Areas_id)); ";
            SqlCommand command = new SqlCommand(query, connect);
            command = DBValueCheking.AddValue(command, "@Name_Announcing", ann.Name_Announcing);
            command = DBValueCheking.AddValue(command, "@Phone_Announcing", ann.Phone_Announcing);
            command = DBValueCheking.AddValue(command, "@Date_Announcing", ann.Date_Announcing);
            command = DBValueCheking.AddValue(command, "@Info_Announcing", ann.Info_Announcing);
            command = DBValueCheking.AddValue(command, "@Categories_id", ann.Categories_id);
            command = DBValueCheking.AddValue(command, "@User_id", ann.User_id);
            command = DBValueCheking.AddValue(command, "@City_id", ann.City_id);
            command = DBValueCheking.CheckValue(command, "@Areas_id", ann.Areas_id);
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
        public static void EditAnnouncing(Announcing ann)
        {
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            string queryString = "UPDATE Announcing SET Name_Announcing = ISNULL(@Name_Announcing, Name_Announcing), Phone_Announcing = ISNULL(@Phone_Announcing, Phone_Announcing), Date_Announcing = ISNULL(@Date_Announcing, Date_Announcing), Info_Announcing = ISNULL(@Info_Announcing, Info_Announcing), Categories_id = ISNULL(@Categories_id, Categories_id), City_id = ISNULL(@City_id, City_id), Areas_id = ISNULL(@Areas_id, Areas_id) WHERE Announcing_id = @Announcing_id";
            SqlCommand command = new SqlCommand(queryString, connect);
            command = DBValueCheking.AddValue(command, "@Name_Announcing", ann.Name_Announcing);
            command = DBValueCheking.AddValue(command, "@Phone_Announcing", ann.Phone_Announcing);
            command = DBValueCheking.AddValue(command, "@Date_Announcing", ann.Date_Announcing);
            command = DBValueCheking.AddValue(command, "@Info_Announcing", ann.Info_Announcing);
            command = DBValueCheking.AddValue(command, "@Categories_id", ann.Categories_id);
            command = DBValueCheking.AddValue(command, "@Announcing_id", ann.Announcing_id);
            command = DBValueCheking.AddValue(command, "@City_id", ann.City_id);
            command = DBValueCheking.CheckValue(command, "@Areas_id", ann.Areas_id);
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
        }
        public static void DeleteAnnouncing(int _id)
        {
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            string queryString = "DELETE FROM Announcing WHERE Announcing_id = @Announcing_id";
            SqlCommand command = new SqlCommand(queryString, connect);
            command = DBValueCheking.AddValue(command, "@Announcing_id", _id);
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
        }
    }
}
