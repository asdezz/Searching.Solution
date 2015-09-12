﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main
{
    // Класс, в котором функции фильтра Объявлений. 
  public  class AnnouncingFilter
    {
        public static DataTable GetCategories()
        {
            string queryString = "SELECT * FROM Categories";
            DataTable table = SqlAccess.CreateCommandQuerySelect(queryString, "CategoriesList");
            return table;
        }
        //int? country,int? city,int? areas,char? Gender_user,int? Date_Bearthday
        public static DataTable GetAnnouncingFilter(DataTable table)
        {
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            string query = "SELECT a.Announcing_id, a.Name_Announcing, c.City_name FROM Announcing a JOIN Cities c ON c.City_id = a.City_id JOIN[UserList] u ON  u.[User_id] = a.[User_id] WHERE a.Categories_id = @Categories_id AND a.City_id = ISNULL(@City_id, a.City_id) AND a.Areas_id = ISNULL(@Areas_id, a.Areas_id) AND u.Gender_user = ISNULL(@Gender_user, u.Gender_user) AND u.Date_Bearthday BETWEEN ISNULL(@MinDateBearthday, u.Date_Bearthday) AND ISNULL(@MaxDateBearthday, u.Date_Bearthday) AND a.Date_Announcing >= ISNULL(@DateAnnouncing, a.Date_Announcing)";
             SqlCommand command = new SqlCommand(query, connect);
            command.Parameters.Add("@Categories_id",SqlDbType.Int);
            command.Parameters.Add("@City_id",SqlDbType.Int);
            command.Parameters.Add("@Areas_id",SqlDbType.Int);
            command.Parameters.Add("@Gender_user", SqlDbType.Char);
            command.Parameters.Add("@MinDate_Bearthday",SqlDbType.Date);
            command.Parameters.Add("@MaxDate_Bearthday", SqlDbType.Date);
            command.Parameters.Add("@Date_Announcing", SqlDbType.Date);
            command.Parameters["@Categories_id"].Value =table.Select("Categories_id");
            command.Parameters["@City_id"].Value =table.Select("City_id");
            command.Parameters["@Areas_id"].Value = table.Select("Areas_id");
            command.Parameters["@Gender_user"].Value = table.Select("Gender_user");
            command.Parameters["@MinDateBearthday"].Value = table.Select("MinDateBearthday");
            command.Parameters["@MaxDateNearthday"].Value = table.Select("MaxDateBearthday");
            command.Parameters["@DateAnnouncing"].Value = table.Select("DateAnnouncing");
            command.ExecuteNonQuery();
            table = SqlAccess.CreateQuery(command,"GetAnnouncingWithFilter");
            return table;
        }

        public static DataTable GetAnnouncingFromCity(int City_id)
        {
            string connectionString = SqlAccess.GetConnectionString();
            SqlConnection connect = new SqlConnection(connectionString);
            string queryString = "SELECT * FROM Announcing WHERE City_id =@City_id";
            SqlCommand command = new SqlCommand(queryString, connect);
            command.ExecuteNonQuery();
            DataTable table = SqlAccess.CreateQuery(command, "AnnouncingListFromCity");
            return table;
        }

        public static DataTable GetAnnouncingForAreasOfCity(int AreasOfCity_id)
        {
            string connectString = SqlAccess.GetConnectionString();
            string queryString = "SELECT * FROM Announcing WHERE Areas_id = @AreasOfCity_id";
            SqlConnection connect = new SqlConnection(connectString);
            SqlCommand command = new SqlCommand(queryString, connect);
            command.Parameters.Add("@AreasOfCity_id", SqlDbType.Int);
            command.Parameters["@AreasOfCity_id"].Value = AreasOfCity_id;
            command.ExecuteNonQuery();
            DataTable table = SqlAccess.CreateQuery(command, "AnnouncingforAreasOfCity");
            return table;
        }
    }
}