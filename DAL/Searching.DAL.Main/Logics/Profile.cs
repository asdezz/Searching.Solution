using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main
{
   public class Profile
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
        public static DataTable PostRegistration(DataTable table)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "SELECT * FROM User WHERE Mail=@Mail, FIO=@FIO, Phone=@Phone,Gender_User=@Gender_user, Date_Bearthday=@Date_Bearthday,Password=@pass, Info=@info,Country_id=@Country_id,Type_login=@type_login";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString,connect);
            table = SqlAccess.CreateQuery(command,"Users");
            return table;
        }
    }
}
