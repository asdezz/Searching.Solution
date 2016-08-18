﻿
using SearchingLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main.Logics.BD
{
   public static class MessagesFunction
    {
        public static ReturnValue AddMessages(Messages msg)
        {
            ReturnValue result = new ReturnValue();
            string query = "insert into MessageList(Date_message,Message,Sender_id,Status_id,Session_id) values(@DateMessage, @Message, @Sender_id, @Status_id, @Session_id)";
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(query, connect);
            command = DBValueCheking.AddValue(command, "@DateMessage", msg.Date_Message);
            command = DBValueCheking.AddValue(command, "@Message", msg.Message);
            command = DBValueCheking.AddValue(command, "@Sender_id", msg.Sender_id);
            command = DBValueCheking.AddValue(command, "@Status_id", msg.Status_id);
            command = DBValueCheking.AddValue(command, "@Session_id", msg.Session_id);
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
                result.Code = true;
                result.Message = "Операция прошла успешно";
            }
            catch (Exception ex)
            {
                Logger.CreateLog(ex);
                result.Code = false;
                result.Message = "Ошибка операции добавления сообщения";
                //throw ex;
            }
            finally
            {
                connect.Close();
            }

            //    var table = SqlAccess.CreateQuery(command, "MessageList");
               // }
                return result;
            
        }
    }
}
