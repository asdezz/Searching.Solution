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
   public  static class Profile
    {
        //Класс, в котором функции связанны с пользователем
        public static DataTable GetUser(int User_id)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "SELECT * FROM User WHERE User_id = @User_id";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command.Parameters.Add("@User_id", SqlDbType.Int);
            command.Parameters["@User_id"].Value = User_id;
            command.ExecuteNonQuery();
            DataTable table = SqlAccess.CreateQuery(command, "GetUserList");
            return table;
        }
        public static DataTable PostRegistration(UserList user)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "SELECT * FROM User WHERE Mail=@Mail, FIO=@FIO, Phone=@Phone,Gender_User=@Gender_user, Date_Bearthday=@Date_Bearthday,Password=@pass, Info=ISNULL(@info,Info),Country_id=ISNULL(@Country_id,Country_id),Type_login=@type_login,City_id=ISNULL(@City_id,City_id)";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString,connect);
            command = DBValueCheking.AddValue(command, "@Mail", user.Mail);
            command = DBValueCheking.AddValue(command, "@FIO", user.FIO);
            command = DBValueCheking.AddValue(command, "Phone", user.Phone);
            command = DBValueCheking.AddValue(command, "@Gender_user", user.Gender_user);
            command = DBValueCheking.AddValue(command, "@Date_Bearthday", user.Date_Bearthday);
            command = DBValueCheking.AddValue(command, "pass", user.Password);
            command = DBValueCheking.CheckValue(command, "@info", user.Info);
            command = DBValueCheking.CheckValue(command, "@Country_id", user.Country_id);
            command = DBValueCheking.AddValue(command, "@type_login", user.Type_login);
            command = DBValueCheking.CheckValue(command, "@City_id", user.City_id);           
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
            DataTable table = SqlAccess.CreateQuery(command, "Users");
            return table;
             
        }
        public static DataTable Auth(UserList user)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "";
            SqlConnection connect = new SqlConnection(queryString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command = DBValueCheking.CheckValue(command, "@Phone", user.Phone);
            command = DBValueCheking.CheckValue(command, "@Mail", user.Mail);
            command = DBValueCheking.AddValue(command,"@Password", user.Password);
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
            DataTable table = SqlAccess.CreateQuery(command, "User");
            return table;
        }
        public static DataTable EditProfile(UserList user)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "UPDATE UserList SET Mail = ISNULL(@Mail, Mail), FIO = ISNULL(@FIO, FIO), Phone = ISNULL(@Phone, Phone), Gender_user = ISNULL(@Gender_user, Gender_user), Date_Bearthday = ISNULL(@Date_Bearthday, Date_Bearthday), Info = ISNULL(@Info, Info), Country_id = ISNULL(@Country_id, Country_id), Type_login = ISNULL(@Type_login, Type_login), City_id = ISNULL(@City_id, City_id) WHERE User_id = @User_id";
            SqlConnection connect = new SqlConnection(queryString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command = DBValueCheking.CheckValue(command,"@Mail",user.Mail);
            command = DBValueCheking.CheckValue(command, "@FIO",user.FIO);
            command = DBValueCheking.CheckValue(command, "@Phone",user.Phone);
            command = DBValueCheking.CheckValue(command, "@Gender_user", user.Gender_user);
            command = DBValueCheking.CheckValue(command, "@Date_Bearthday", user.Date_Bearthday);
            command = DBValueCheking.CheckValue(command, "@Info", user.Info);
            command = DBValueCheking.CheckValue(command, "@Country_id", user.Country_id);
            command = DBValueCheking.CheckValue(command, "@Type_login", user.Type_login);
            command = DBValueCheking.CheckValue(command, "@City_id", user.City_id);
            command = DBValueCheking.AddValue(command, "@User_id", user.User_id);
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
            DataTable table = SqlAccess.CreateQuery(command, "EditProfile");
            return table;
        }
    }
}
