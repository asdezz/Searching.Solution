using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main
{
    //Класс, описывающий функции связанные с месторасположением или локацией 
   public  static class Location
    {
        public static DataTable GetCountryList()
        {
            string queryString = "SELECT * FROM  Country ORDER BY Name_country";
            DataTable table = SqlAccess.CreateCommandQuerySelect(queryString, "ContryList");
            return table;

        }

        public static DataTable GetCityForCountry(int Country_id)
        {
            string connectString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectString);
            string queryString = "SELECT * FROM  Cities WHERE Country_id =@Country_id";
            SqlCommand command = new SqlCommand(queryString, connect);
            command.Parameters.Add("@Country_id", SqlDbType.Int);
            command.Parameters["@Country_id"].Value = Country_id;
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
            DataTable table = SqlAccess.CreateQuery(command, "GetCityFromCoubtry");
            return table;
        }

        public static DataTable GetAreasOfCity(int City_id)
        {
            string connectingString = SqlAccess.GetConnectionString();
            string queryString = "SELECT * FROM AreasOfCity WHERE City_id = @City_id";
            SqlConnection connect = new SqlConnection(connectingString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command.Parameters.Add("@City_id", SqlDbType.Int);
            command.Parameters["@City_id"].Value = City_id;
            try
            {
                connect.Open();
                command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Logger.CreateLog(ex);
                throw ex;
            }
            finally
            {
                connect.Close();
            }
            DataTable table = SqlAccess.CreateQuery(command, "GetAreasOfCity");
            return table;
        }
    }
}
