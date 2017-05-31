using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Killer_app.Model;

namespace Killer_app
{
    class Database
    {
        private readonly static string connectionstring = @"Server= localhost\sqlexpress; Database= Killer-app; Integrated Security = True";

        public static SqlConnection Connection
        {
            get
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                conn.Open();
                return conn;
            }
        }
        public bool ExecuteNonQuery(string query)
        {
            using (SqlCommand comm = new SqlCommand(query, Connection))
            {
                try
                {
                    Console.WriteLine("ExecuteNonQuery Executed");
                    comm.ExecuteNonQuery();
                    return true;
                }
                catch (Exception e)
                {
                    Console.Write("an Error occured: ", e.Message);
                }
            }
            return false;
        }
        public int ExecuteReaderInt(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, Connection);
                if (command.ExecuteScalar() != null)
                {
                    Console.WriteLine("Execute reader executed");
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return -1;
        }
        public string ExecuteReaderString(string query)
        {
            try
            {

                SqlCommand command = new SqlCommand(query, Connection);
                if (command.ExecuteScalar() != null)
                {
                    Console.WriteLine("Execute reader executed");
                    return Convert.ToString(command.ExecuteScalar());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            return String.Empty;
        }
        public List<int> ExecuteReaderListInt(string query, int amount)
        {
            try
            {
                List<int> list = new List<int>();
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    for (int i = 0; i < amount; i++)
                    {
                        list.Add(reader.GetInt32(i));
                    }
                }
                Console.WriteLine("Execute reader executed");
                return list;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: " + exception.Message);
            }
            return null;
        }

        public List<object[]> ExecuteReaderListObject(string query)
        {

            try
            {
                List<object[]> table = new List<object[]>();

                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    object[] row = new object[reader.FieldCount];
                    reader.GetValues(row);
                    table.Add(row);
                }
                return table;

            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occurred: " + exception.Message);
                return null;
            }
        }
        public object[] ExecuteReaderObject(string query)
        {
            try
            {
                SqlCommand command = new SqlCommand(query, Connection);
                SqlDataReader reader = command.ExecuteReader();
                object[] data = null;
                while (reader.Read())
                {
                    data = new object[reader.FieldCount];
                    reader.GetValues(data);
                }
                return data;
            }
            catch (Exception exception)
            {
                Console.WriteLine("An error occurred: " + exception.Message);
                return null;
            }
        }
        public bool ExecuteProcedure(string procedurename, string parameterName, int intValue, string stringValue)
        {
            try
            {
                SqlCommand command = new SqlCommand(procedurename, Connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if(stringValue == null)
                {
                    command.Parameters.Add(new SqlParameter(parameterName, intValue));
                }
                else
                {
                    command.Parameters.Add(new SqlParameter(parameterName, stringValue));
                }
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
                return false;
            }
        }

    

    }
}
