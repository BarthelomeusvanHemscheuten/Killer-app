using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Model;

namespace Killer_app.Data
{
    interface IGameContext
    {
        bool Insert(Game game);

        bool Update(Game game);

        bool Delete(int id);

        bool UpdateHours(int gameID, string userNaam, int uren);
        List<object[]> GetAllGames();
        List<int> GetGamesIDTag(string tagnaam);
        List<object[]> SearchGames(string gamenaam);
        object[] GetGame(int gameID);
    }
}
