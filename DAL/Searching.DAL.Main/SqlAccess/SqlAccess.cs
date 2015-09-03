using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching.DAL.Main
{
   public class SqlAccess
    {
        public static void CreateCommandNonQuery(SqlCommand command)
        { 
                command.ExecuteNonQuery();
            
        }

        public static DataTable CreateCommandQuerySelect(string queryString, string tableName)
        {

            string connectionString = GetConnectionString();
            DataSet dataSet = new DataSet("Searching");
            DataTable table = new DataTable(tableName);
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                // Open the connection.
                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                // Fill the DataTable.
                adapter.Fill(table);

                //Add Table to DataSet
                dataSet.Tables.Add(table);

                // Close the connection.
                connection.Close();
            }
            return table;
        }

            public static DataTable CreateQuery(SqlCommand command, string TableName)
        {
            DataTable table = new DataTable(TableName);
            command.Connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            command.Connection.Close();

            return table;
        }

        static public string GetConnectionString()
        {
            return "Persist Security Info = False; Integrated Security = true; Initial Catalog = Searching; server = (local)";
        }
    }



        
    }

