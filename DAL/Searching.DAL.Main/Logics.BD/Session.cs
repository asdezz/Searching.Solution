using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main.Logics.BD
{
   public static class Session
    {
       public static ReturnValue Create(Messages msg)
        {
            ReturnValue result = new ReturnValue();
            SqlDataAdapter adapter = new SqlDataAdapter();
            //string query = "INSERT INTO SessionList(Sender_id,Recipient_id,Announcing_id,Type_id) VALUES(@Sender_id, @Recipient_id, @Ann_id, @Type_id) SELECT SCOPE_IDENTITY() AS id";
            var query = "INSERT INTO SessionList(Owner_id,Type_id,Announcing_id) VALUES(@Owner_id,@Type_id,@Ann_id) SELECT @Session_id= SCOPE_IDENTITY()";
            string connectionString = SqlAccess.GetConnectionString();
            using (SqlConnection connect = new SqlConnection(connectionString))
            {   
                query = Helper.UpdateQuerySession.AddSubscriber_Sender(query);
                query = Helper.UpdateQuerySession.AddSubscriber_Recipient(query, msg.Recipient_id);
                query = Helper.UpdateQuerySession.AddReturnValue(query);
                SqlCommand command = new SqlCommand(query, connect);
                command = DBValueCheking.AddValue(command, "@Sender_id", msg.Sender_id);
                command = DBValueCheking.AddWithCheckValue(command, "@Recipient_id", msg.Recipient_id);
                command = DBValueCheking.AddValue(command, "@Owner_id", msg.Sender_id);
                command = DBValueCheking.AddWithCheckValue(command, "@Ann_id", msg.Announcing_id);
                command = DBValueCheking.AddValue(command, "@Type_id", msg.Type_id);
                command = DBValueCheking.AddWithCheckValue(command, "@Session_id", null);
                var table = SqlAccess.CreateQueryWithTran(command, "NewSession_id");
                foreach(DataRow row in table.Rows)
                {
                    result.Session_id = int.Parse(row["id"].ToString());
                }
            }
            return result;
        }

        public static ReturnValue Check(Messages msg)
        {
            ReturnValue result= new ReturnValue();
            //var query = "SELECT * FROM SessionList sl where @Sender_id in (sl.Sender_id,sl.Recipient_id) and (@Recipient_id is Null or  @Recipient_id in (sl.Sender_id,sl.Recipient_id)) and ISNULL( sl.Announcing_id,0) = ISNULL(@Ann_id,0)";
            //  var query = "select * from SubscribeList_Session s1 join SubscribeList_Session s2 on s1.Session_id=s2.Session_id where s1.User_id=@Sender_id and s2.User_id=@Recipient_id or s1.User_id=@Recipient_id and s2.User_id=@Sender_id  and s1.User_id !=s2.User_id";
            var query = "SELECT sl.Session_id FROM SubscribeList_Session s1 JOIN SubscribeList_Session s2 ON s1.Session_id = s2.Session_id JOIN SessionList sl ON s1.Session_id = sl.Session_id WHERE ( s1.User_id = @Sender_id AND ( s2.User_id = @Recipient_id OR (s1.User_id = @Recipient_id AND s2.User_id = @Sender_id AND s1.User_id != s2.User_id AND s1.Session_id != s2.Session_id) ) AND @Ann_id IS NULL  ) OR (s1.User_id = @Sender_id AND sl.Announcing_id = @Ann_id)";
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

        public static int? GetSession(Messages msg)
        {
            ReturnValue result = new ReturnValue();
            result = Check(msg);
            if (result.Session_id == null)
            {
                result = Create(msg);
            }
            return result.Session_id;
        }
    }
}
