using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Model;

namespace Killer_app.Data
{
    interface IUserContext
    {
        bool Login(string naam, string wachtwoord);

        bool InsertGame(string usernaam, int gameid);

        List<int> GetGamesID(string usernaam);
        int GetProfiel(string usernaam);
        int GetWinkelwagen(string usernaam);
        List<object[]> GetListUsers(List<string> usernamen);
        object[] GetUser(string usernaam);
    } 
}
