using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Searching.DAL.Main;

namespace Searching.DAL.Main
{
    public class SqlQuery
    {
        
        
       
        
        

        
        
        
        
        
        
        
        
        
        public static DataTable PostRegistration(char? Mail = null, char? FIO = null, int? Phone = null, char? Gender_user = null, int? Date_Bearthday = null, char? pass = null, string info = null, int? Country_id = null, int? type_login = null,int? City_id=null)
        {
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            string queryString = "SELECT * FROM User WHERE Mail=@Mail, FIO=@FIO, Phone=@Phone,Gender_User=@Gender_user, Date_Bearthday=@Date_Bearthday,Password=@pass, Info=@info,Country_id=@Country_id,Type_login=@type_login";
            SqlCommand command = new SqlCommand(queryString, connect);
            command.Parameters.Add("@Phone",SqlDbType.Int);
            command.Parameters.Add("@Date_Bearthday", SqlDbType.Int);
            command.Parameters.Add("@Country_id", SqlDbType.Int);
            command.Parameters.Add("@type_login", SqlDbType.Int);
            command.Parameters.Add("@Mail", SqlDbType.Char);
            command.Parameters.Add("@FIO", SqlDbType.Char);
            command.Parameters.Add("@Gender_user", SqlDbType.Char);
            command.Parameters.Add("@pass", SqlDbType.Char);
            command.Parameters.Add("@Info", SqlDbType.Char);
            DataTable table = SqlAccess.CreateCommandQuerySelect(queryString, "");
            command.Parameters.AddWithValue("@info",info);
            command.Parameters["@Mail"].Value =Mail;
            command.Parameters["@Phone"].Value =Phone;
            command.Parameters["@Date_Bearthday"].Value =Date_Bearthday;
            command.Parameters["@Country_id"].Value =Country_id;
            command.Parameters["@type_login"].Value =type_login;
            command.Parameters["@FIO"].Value =FIO;
            command.Parameters["@Gender_user"].Value =Gender_user;
            command.Parameters["@pass"].Value =pass;
            command.ExecuteNonQuery();
            return table;
        }
        //
        public static DataTable UpdateUserInfo(int User_id,char? Mail = null, char? FIO = null, int? Phone = null, char? Gender_user = null, int? Date_Bearthday = null, char? pass = null, string info = null, int? Country_id = null, int? type_login = null, int? City_id = null)
        {
            string queryString = "UPDATE r SET r.Mail =@mail, r.Phone =@Phone, r.FIO=@FIO,r.Gender_user=@Gender_user,r.Date_Bearthday=@Date_Bearthday,r.Password=@pass,r.Info=@info,r.Country_id=@Country_id,r.Type_login=@type_login FROM User r WHERE  r.[User_id] = @User_id";
            DataTable table = SqlAccess.CreateCommandQuerySelect(queryString, "");
            return table;
        }

        
        
        

        public static DataTable  GetCityAll()
        { 
            
            string queryString = "SELECT * FROM  Cities c (Nolock)";
            DataTable table = SqlAccess.CreateCommandQuerySelect(queryString, "CityList");
            return table;
        }

        
    }

}

