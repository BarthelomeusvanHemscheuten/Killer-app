using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Killer_app.Data
{
    class TagSQLContext : ITagContext
    {
        Database database;
        
        public TagSQLContext()
        {
            database = new Database();
        }
        public bool AddGame(int gameID, string tagNaam)
        {
            string query = @"INSERT INTO [Tag-Game](Game-ID, Naam) VALUES(@gameID, '@tagNaam')";
            query = query.Replace("@gameID", gameID.ToString())
                .Replace("@tagNaam", tagNaam);
            return database.ExecuteNonQuery(query);
        }
        public bool DeleteGame(int gameID, string tagNaam)
        {
            string query = @"DELETE FROM [Tag-Game] WHERE [Game-ID] = @gameID AND [Naam] = '@tagNaam'";
            query = query.Replace("@gameID", gameID.ToString())
                .Replace("@tagNaam", tagNaam);
            return database.ExecuteNonQuery(query);
        }
        public bool EditDescription(string tagNaam, string description)
        {
            string query = @"UPDATE [Tag] SET [Descriptie] = '@description' WHERE [Naam] = '@tagNaam'";
            query = query.Replace("@description", description)
                .Replace("@tagNaam", tagNaam);
            return database.ExecuteNonQuery(query);

        }
        public bool AddTag(string tagNaam, string description)
        {
            string query = @"INSERT INTO [Tag]([Naam], [Descriptie]) VALUES('@tagNaam', '@description'";
            query = query.Replace("@tagNaam", tagNaam)
                .Replace("@description", description);
            return database.ExecuteNonQuery(query); 
        }
    }
}
