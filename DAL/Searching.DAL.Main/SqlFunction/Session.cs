using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main.SqlFunction
{
   public static class Session
    {
       public static ReturnValue Create(Messages msg)
        {
            ReturnValue result = new ReturnValue();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string query = "INSERT INTO SessionList(Sender_id,Recipient_id,Announcing_id,Type_id) VALUES(@Sender_id, @Recipient_id, @Ann_id, @Type_id) SELECT SCOPE_IDENTITY() AS id";
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connect);
            command = DBValueCheking.AddValue(command, "@Sender_id", msg.Sender_id);
            command = DBValueCheking.AddWithCheckValue(command, "@Recipient_id", msg.Recipient_id);
            command = DBValueCheking.AddWithCheckValue(command, "@Ann_id", msg.Announcing_id);
            command = DBValueCheking.AddValue(command, "@Type_id", msg.Type_id);
            //try
            //{
            //    connect.Open();
            //    command.ExecuteNonQuery();
            //    result.Code = true;
            //    result.Message = "Операция прошла успешно!";
            //}catch(Exception ex)
            //{
            //    Logger.CreateLog(ex);
            //    result.Code = false;
            //    result.Message = "Ошибка запроса";
            //  //  throw ex;
            //}
            //finally
            //{
            //    connect.Close();
            //}
            var table = SqlAccess.CreateQuery(command, "GetNewSession");
            foreach(DataRow row in table.Rows)
            {
                result.Session_id = int.Parse(row["id"].ToString());
            }
            return result;
        }

        public static ReturnValue Check(Messages msg)
        {
            ReturnValue result= new ReturnValue();
            var query = "SELECT * FROM SessionList sl where(@Sender_id is NULL or sl.Sender_id = @Sender_id) and(@Recipient_id is NULL or sl.Recipient_id = @Recipient_id) and(@Ann_id is NULL or sl.Announcing_id = @Ann_id)";
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connect);
            command = DBValueCheking.AddValue(command, "@Sender_id", msg.Sender_id);
            command = DBValueCheking.AddWithCheckValue(command, "@Recipient_id", msg.Recipient_id);
            command = DBValueCheking.AddWithCheckValue(command, "@Ann_id", msg.Announcing_id);
            //try
            //{
            //    connect.Open();
            //    command.ExecuteNonQuery();
            //}
            //catch(Exception ex)
            //{
            //    Logger.CreateLog(ex);
            //    throw ex;
            //}
            //finally
            //{
            //    connect.Close();
            //}
            var table = SqlAccess.CreateQuery(command, "GetSession");
            var count = table.Rows.Count;
            if (count == 0)
            {
                result.Code = false;
            }else
            {
                result.Code = true;
                foreach(DataRow row in table.Rows)
                {
                    result.Session_id = int.Parse(row["Session_id"].ToString());
                }
            }
            return result;
        }

        public static int GetSession(Messages msg)
        {
            ReturnValue result = new ReturnValue();
            result = Check(msg);
            if (result.Code == false)
            {
                result = Create(msg);

            }
            return result.Session_id;
        }
    }
}
