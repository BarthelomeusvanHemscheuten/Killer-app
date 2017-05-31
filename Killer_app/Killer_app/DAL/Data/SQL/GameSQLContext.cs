using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Model;
using System.Data.SqlClient;

namespace Killer_app.Data
{
    class GameSQLContext : IGameContext
    {
        Database database;
        public GameSQLContext()
        {
            database = new Database();
        }

        public bool Insert(Game game)
        {
            string query = "INSERT INTO [Game] ([Naam], [Prijs], [Trailer], [Score], [OudePrijs], [Foto]) VALUES(@naam, @prijs, @trailer, @score, @oudePrijs, @image)";

            using (SqlCommand comm = new SqlCommand(query, Database.Connection))
            {
                comm.Parameters.AddWithValue("@naam", game.Naam);
                comm.Parameters.AddWithValue("@prijs", game.Prijs);
                comm.Parameters.AddWithValue("@trailer", game.Trailer);
                comm.Parameters.AddWithValue("@score", game.Score);
                comm.Parameters.AddWithValue("@oudePrijs", game.OudePrijs);
                comm.Parameters.AddWithValue("@image", game.Image);
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
        public bool Update(Game game)
        {

            string query = "UPDATE [Game] SET [Naam] = @naam, [Score] = @score, [Foto] = @image, [OudePrijs] = @oudePrijs, [Trailer] = @trailer,  [Prijs] = @prijs WHERE [Game-ID] = @id";
            using (SqlCommand comm = new SqlCommand(query, Database.Connection))
            {
                comm.Parameters.AddWithValue("@id", game.ID);
                comm.Parameters.AddWithValue("@naam", game.Naam);
                comm.Parameters.AddWithValue("@prijs", game.Prijs);
                comm.Parameters.AddWithValue("@trailer", game.Trailer);
                comm.Parameters.AddWithValue("@score", game.Score);
                comm.Parameters.AddWithValue("@oudePrijs", game.OudePrijs);
                comm.Parameters.AddWithValue("@image", game.Image);
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
        public bool Delete(int id)
        {
            return database.ExecuteProcedure("DeleteGame", "@GameID", id, null);

        }
        public bool UpdateHours(int gameID, string userNaam, int uren)
        {
            string query_hours = @"SELECT [Uren] FROM [Game-User] WHERE [User-Naam] = @userNaam";
            query_hours = query_hours.Replace("@userNaam", userNaam);
            int hours = database.ExecuteReaderInt(query_hours) + uren;
            string query = @"UPDATE [Game-User] SET [Uren] = @uren WHERE [User-Naam] = @userNaam AND [Game-ID] = @gameID";
            query = query.Replace("@userNaam", userNaam)
                .Replace("@gameID", gameID.ToString())
                .Replace("@uren", hours.ToString());
            return database.ExecuteNonQuery(query);
        }
        public List<object[]> GetAllGames()
        {
            string query = "SELECT * FROM [Game] ORDER BY [Naam]";
            return database.ExecuteReaderListObject(query);
        }
        public List<int> GetGamesIDTag(string tagnaam)
        {
            string query = "SELECT [Game-ID] FROM [Tag-Game] WHERE [Naam] = '@tagnaam'";
            query = query.Replace("@tagnaam", tagnaam);
            return  database.ExecuteReaderListInt(query, 1);

        }
    
        public List<object[]> SearchGames(string gamenaam)
        {
            string query = "SELECT * FROM [Game] WHERE [Naam] LIKE '%@gamenaam%'";
            query = query.Replace("@gamenaam", gamenaam);
            return database.ExecuteReaderListObject(query);
        }
        public object[] GetGame(int gameID)
        {
            string query = "SELECT * FROM [Game] WHERE [Game-ID] = @gameID";
            query = query.Replace("@gameID", gameID.ToString());
            return database.ExecuteReaderObject(query);
        }


    }
}
