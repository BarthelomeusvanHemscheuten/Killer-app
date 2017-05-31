using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Model;

namespace Killer_app.Data
{
    interface ILijstContext
    {
        bool AddGameWinkelwagen(int gameID, int winkelwagenID);
        List<int> GetGamesIDWinkelwagen(int winkelwagendID);


        bool DeleteGameWinkelwagen(int gameID, int winkelwagenID);
        bool AddGameVerlanglijst(int gameID, int verlanglijstID);
        List<int> GetGamesIDVerlanglijst(int verlanglijstID);
        bool UpdatePriceWinkelwagen(decimal price, int winkelwagenID);
        bool DeleteGameVerlanglijst(int gameID, int verlanglijstID);
        bool DeleteAllGamesWinkelwagen(int winkelwagenID);
        int GetWinkelwagenIDFromUser(string usernaam);
        int GetVerlanglijstIDFromUser(string usernaam);
        object[] GetWinkelwagen(int winkelwagenID);
        object[] GetVerlanglijst(int verlanglijstID);
        
    }
}
