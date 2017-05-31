using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Model;

namespace Killer_app.Data
{
    class LijstSQLContext : ILijstContext
    {
        Database database;
        public LijstSQLContext()
        {
            database = new Database();
        }
        public bool AddGameVerlanglijst(int gameID, int verlanglijstID)
        {
            string query = @"INSERT INTO [Verlanglijst-Game]([Verlanglijst-ID], [Game-ID]) VALUES (@verlanglijstID, @gameID)";
            query = query.Replace("@gameID", gameID.ToString()).Replace("@verlanglijstID", verlanglijstID.ToString());
            return database.ExecuteNonQuery(query);
        }

        public bool AddGameWinkelwagen(int gameID, int winkelwagenID)
        {
            string query = @"INSERT INTO [Winkelwagen-Game]([Winkelwagen-ID], [Game-ID]) VALUES (@winkelwagenID, @gameID)";
            query = query.Replace("@gameID", gameID.ToString()).Replace("@winkelwagenID", winkelwagenID.ToString());
            return database.ExecuteNonQuery(query);
        }

        public bool UpdatePriceWinkelwagen(decimal price, int winkelwagenID)
        {
            string query = @"UPDATE [WinkelWagen] SET [Price] = @price WHERE [Winkelwagen-ID] = @winkelwagenID";
            query = query.Replace("@price", price.ToString())
                .Replace("@winkelwagenID", winkelwagenID.ToString());
            return database.ExecuteNonQuery(query);
        }

        public bool DeleteGameVerlanglijst(int gameID, int verlanglijstID)
        {
            string query = @"DELETE FROM [Verlanglijst-Game] WHERE [Verlanglijst-ID] = @verlanglijstID AND [Game-ID] = @gameID";
            query = query.Replace("@verlanglijstID", verlanglijstID.ToString()).Replace("@gameID", gameID.ToString());
            return database.ExecuteNonQuery(query);
        }

        public bool DeleteGameWinkelwagen(int gameID, int winkelwagenID)
        {
            string query = @"DELETE FROM [Winkelwagen-Game] WHERE [Winkelwagen-ID] = @winkelwagenID AND [Game-ID] = @gameID";
            query = query.Replace("@winkelwagenID", winkelwagenID.ToString()).Replace("@gameID", gameID.ToString());
            return database.ExecuteNonQuery(query);
        }

        public List<int> GetGamesIDVerlanglijst(int verlanglijstID)
        {
            string query = @"SELECT [Game-ID] FROM [Verlanglijst-Game] WHERE [Verlanglijst-ID] - @verlanglijstID";
            query = query.Replace("@verlanglijstID", verlanglijstID.ToString());
            return database.ExecuteReaderListInt(query, 1);
        }

        public List<int> GetGamesIDWinkelwagen(int winkelwagenID)
        {
            string query = @"SELECT [Game-ID] FROM [Winkelwagen-Game] WHERE [Winkelwagen-ID] = @winkelwagenID";
            query = query.Replace("@winkelwagenID", winkelwagenID.ToString());
            return database.ExecuteReaderListInt(query, 1);
        }
        public bool DeleteAllGamesWinkelwagen(int winkelwagenID)
        {
            string query = @"DELETE FROM [Winkelwagen-Game] WHERE [Winkelwagen-ID] = @winkelwagenID";
            query = query.Replace("@winkelwagenID", winkelwagenID.ToString());
            return database.ExecuteNonQuery(query);
        }
        public int GetWinkelwagenIDFromUser(string usernaam)
        {
            string query = @"SELECT [Winkelwagen-ID] FROM [Winkelwagen] WHERE [User-Naam] = @usernaam";
            query = query.Replace("@usernaam", usernaam);
            return database.ExecuteReaderInt(query);

        }
        public int GetVerlanglijstIDFromUser(string usernaam)
        {
            string query = @"SELECT [Verlanglijst-ID] FROM [Verlanglijst] WHERE [User-Naam] = @usernaam";
            query = query.Replace("@usernaam", usernaam);
            return database.ExecuteReaderInt(query); 
        }
        public object[] GetWinkelwagen(int winkelwagenID)
        {
            string query = @"SELECT * FROM [Winkelwagen] WHERE [Winkelwagen-ID] = @winkelwagenID";
            query = query.Replace("@winkelwagenID", winkelwagenID.ToString());
            return database.ExecuteReaderObject(query);
        }
        public object[] GetVerlanglijst(int verlanglijstID)
        {
            string query = @"SELECT * FROM [Verlanglijst] WHERE [Verlanglijst-ID] = @verlanglijstID";
            query = query.Replace("@verlanglijstID", verlanglijstID.ToString());
            return database.ExecuteReaderObject(query);
        }
    }
}
