
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
        public static ReturnValue PostRegistration(UserList user)
        {
            string connectString = SqlAccess.GetConnectionString();
            ReturnValue value = new ReturnValue();
            value.Code = -1;
            using (SqlConnection connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlTransaction tran = connect.BeginTransaction();
                SqlParameter param = new SqlParameter(); 
                string procedureName = "RegUser";
                SqlCommand command = connect.CreateCommand();
                command.Transaction = tran;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                param = DBValueCheking.AddSqlParamInput("@Mail", SqlDbType.VarChar, user.Mail);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@PassNew", SqlDbType.NVarChar, user.Password);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@Name", SqlDbType.VarChar, user.Name);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@LastName", SqlDbType.VarChar, user.LastName);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@Phone", SqlDbType.TinyInt, user.Phone);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@Gender_user", SqlDbType.Char, user.Gender_user);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@Date_Bearthday", SqlDbType.Date, user.Date_Bearthday);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@Type_login", SqlDbType.TinyInt, user.Type_login);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@City_id", SqlDbType.Int, user.City_id);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@Country_id", SqlDbType.Int, user.Country_id);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@Info", SqlDbType.VarChar, user.Info);
                command.Parameters.Add(param);
                try
                {
                    command.ExecuteNonQuery();
                    tran.Commit();
                    value.Code = 0;
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    Logger.CreateLog(ex);
                    value.Message = ex.Message;
                    //throw ex;
                }
                finally
                {
                    connect.Close();
                }
            }
            
            return value;
             
        }
        public static ReturnValue  Auth(UserList user)
        {
            ReturnValue value = new ReturnValue();
            value.Code = -1;
            string connectString = SqlAccess.GetConnectionString();
            using (SqlConnection connect = new SqlConnection(connectString))
            {
                connect.Open();
                SqlTransaction tran = connect.BeginTransaction();
                SqlParameter param = new SqlParameter();
                string procedureName = "CheckPass";
                SqlCommand command = connect.CreateCommand();
                command.Transaction = tran;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procedureName;
                param = DBValueCheking.AddSqlParamInput("@Mail", SqlDbType.VarChar, user.Mail);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamInput("@Pass", SqlDbType.NVarChar, user.Password);
                command.Parameters.Add(param);
                param = DBValueCheking.AddSqlParamOutput("isValid", SqlDbType.Bit, 10);
                try
                {
                    command.ExecuteNonQuery();
                    tran.Commit();
                    value.Code = ((int)cmd.Parameters["@petName"].Value).Trim();
                }
                catch(Exception ex)
                {
                    tran.Rollback();
                    Logger.CreateLog(ex);
                    value.Message = ex.Message;
                }
                finally
                {
                    connect.Close();
                }
                

                return value;
                
            }
        }

        public static DataTable GetUser(UserList user)
        {
            string connectString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectString);
            string queryString = "SELECT * FROM UserList u WHERE u.Mail=@Mail";
            SqlCommand command = new SqlCommand(queryString, connect);
            command = DBValueCheking.AddValue(command, "@Mail", user.Mail);
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Logger.CreateLog(ex);
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
            command = DBValueCheking.CheckValue(command, "@Name",user.Name);
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
