using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Data;
using Killer_app.Model;

namespace Killer_app.Logic
{
    class LijstRepository
    {
        private ILijstContext context;
        public LijstRepository(ILijstContext context)
        {
            this.context = context;
        }
        public bool AddGameWinkelwagen(int gameID, int winkelwagenID)
        {
            return context.AddGameWinkelwagen(gameID, winkelwagenID);
        }
        public List<int> GetGamesIDWinkelwagen(int winkelwagendID)
        {
            return context.GetGamesIDWinkelwagen(winkelwagendID);
        }


        public bool DeleteGameWinkelwagen(int gameID, int winkelwagenID)
        {
            return context.DeleteGameWinkelwagen(gameID, winkelwagenID);
        }
        public bool AddGameVerlanglijst(int gameID, int verlanglijstID)
        {
            return context.AddGameVerlanglijst(gameID, verlanglijstID);
        }
        public List<int> GetGamesIDVerlanglijst(int verlanglijstID)
        {
            return context.GetGamesIDVerlanglijst(verlanglijstID);
        }

        public bool DeleteGameVerlanglijst(int gameID, int verlanglijstID)
        {
            return context.DeleteGameVerlanglijst(gameID, verlanglijstID);
        }

        public bool DeleteAllGamesWinkelwagen(int winkelwagenID)
        {
            return context.DeleteAllGamesWinkelwagen(winkelwagenID);
        }
        public bool UpdatePriceWinkelwagen(decimal price, int winkelwagenID)
        {
            return context.UpdatePriceWinkelwagen(price, winkelwagenID);
        }
        public int GetVerlanglijstIDFromUser(string usernaam)
        {
            return context.GetVerlanglijstIDFromUser(usernaam);
        }
        public int GetWinkelwagenIDFromUser(string usernaam)
        {
            return context.GetWinkelwagenIDFromUser(usernaam);
        }
        public Winkelwagen GetWinkelwagen(int winkelwagenID)
        {
            object[] data = context.GetWinkelwagen(winkelwagenID);
            return new Winkelwagen((int)data[0], (string)data[1], (decimal)data[2]);
        }
        public Verlanglijst GetVerlanglijst(int verlanglijstID)
        {
            object[] data = context.GetVerlanglijst(verlanglijstID);
            return new Verlanglijst((int)data[0],(string)data[1]);
        }
    }
}
