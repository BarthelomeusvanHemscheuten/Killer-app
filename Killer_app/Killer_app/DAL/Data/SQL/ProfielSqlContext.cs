using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using Killer_app.Model;

namespace Killer_app.Data
{
    class ProfielSqlContext : IProfielContext
    {
        Database database;
        public ProfielSqlContext()
        {
            database = new Database();
        }
        public bool EditProfiel(Profiel profiel)
        {
            string query = "UPDATE [Profiel] SET [Descriptie] = @desc, [Naam] = @naam, [ProfielFoto] = @foto WHERE [Profiel-ID] = @id";
            using (SqlCommand comm = new SqlCommand(query, Database.Connection))
            {
                comm.Parameters.AddWithValue("@id", profiel.ID);
                comm.Parameters.AddWithValue("@naam", profiel.Naam);
                comm.Parameters.AddWithValue("@desc", profiel.Desc);
                comm.Parameters.AddWithValue("@foto", profiel.Foto);
         
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
        public object[] GetProfielFromUser(string userNaam)
        {
            string query = "SELECT * FROM [User] WHERE [User-Naam] = '@naam'";
            query = query.Replace("@naam", userNaam);
            return database.ExecuteReaderObject(query);
        }
        public object[] GetProfiel(int profielID)
        {
            string query = @"SELECT * FROM [Profiel] WHERE [Profiel-ID] = @profielID";
            query = query.Replace("@profielID", profielID.ToString());
            return database.ExecuteReaderObject(query);
        }
    }
}

