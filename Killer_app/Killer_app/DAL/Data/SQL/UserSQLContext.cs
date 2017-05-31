using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Model;
using System.Data.SqlClient;
namespace Killer_app.Data
{
    class UserSQLContext : IUserContext
    {
        Database database;
        public UserSQLContext()
        {
            database = new Database();
        }
        public bool Login(string naam, string wachtwoord)
        {
            string query = "SELECT [Wachtwoord] FROM [User] WHERE [User-Naam] = '@naam'";
            query = query.Replace("@naam", naam);
            return database.ExecuteReaderString(query) == wachtwoord;

        }
        public bool InsertGame(string usernaam, int gameid)
        {
            string query = "INSERT INTO [Game-User](User-Naam, Game-ID) VALUES('@user', '@game')";
            query = query.Replace("@user", usernaam)
                .Replace("@game", gameid.ToString());
            return database.ExecuteNonQuery(query);

        }
        public List<int> GetGamesID(string username)
        {
            string query = "SELECT [Game-User].[Game-ID] FROM [Game-User] WHERE [User-Naam] = '@username'";
            query = query.Replace("@username", username);
            return database.ExecuteReaderListInt(query, 1);
        }
        public int GetProfiel(string usernaam)
        {
            string query = "SELECT ProfielID FROM [User] WHERE User-Naam = '@usernaam'";
            query = query.Replace("@usernaam", usernaam);
            return database.ExecuteReaderInt(query);
        }
        public List<object[]> GetListUsers(List<string> usernamen)
        {
            List<object[]> users = new List<object[]>();
            string query = @"SELECT * FROM [User] WHERE [User-Naam] = @userNaam";
            foreach(string naam in usernamen)
            {
                query = query.Replace("@userNaam", naam);
                users.Add(database.ExecuteReaderObject(query));
            }
            return users;
        }
        public object[] GetUser(string usernaam)
        {
            string query = @"SELECT * FROM [User] WHERE [User-Naam] = '@userNaam'";
            query = query.Replace("@userNaam", usernaam);
            return database.ExecuteReaderObject(query);
        }
        public int GetWinkelwagen(string usernaam)
        {
            string query = @"SELECT [Winkelwagen-ID] FROM [Winkelwagen] WHERE [User-Naam] = @usernaam";
            query = query.Replace("@usernaam", usernaam);
            return database.ExecuteReaderInt(query);
        }
        
    }
}
