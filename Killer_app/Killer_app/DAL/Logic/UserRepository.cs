using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Data;
using Killer_app.Model;

namespace Killer_app.Logic
{
    class UserRepository
    {
        private IUserContext context;

        public UserRepository(IUserContext context)
        {
            this.context = context;
        }

        public bool Login(string naam, string wachtwoord)
        {
            return context.Login(naam, wachtwoord);
        }
        public bool InsertGame(string usernaam, int gameid)
        {
            return context.InsertGame(usernaam, gameid);
        }
        public List<int> GetGamesID(string usernaam)
        {
            return context.GetGamesID(usernaam);
          
        }
        public int GetProfielID(string usernaam)
        {
            return context.GetProfiel(usernaam);
        }
        public User GetUser(string usernaam)
        {
            object[] data = context.GetUser(usernaam);
            if(data == null)
            {
                return null;
            }
            return new User((string)data[0], (int)data[1], (string)data[2], (bool)data[3]);
        }

    }
}
