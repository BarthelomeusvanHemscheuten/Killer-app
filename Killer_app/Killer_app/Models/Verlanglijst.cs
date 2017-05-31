using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Data;
using Killer_app.Logic;

namespace Killer_app.Model
{
    public class Verlanglijst
    {
        UserRepository userrepo = new UserRepository(new UserSQLContext());
        GameRepository gamerepo = new GameRepository(new GameSQLContext());
        public int ID { get; private set; }
        public List<Game> Games { get; private set; }
        public List<Bundel> Bundels { get; private set; }
        public User User { get; private set; }

        public Verlanglijst(int verlanglijstID, string usernaam)
        {
            ID = verlanglijstID;
            User = userrepo.GetUser(usernaam);
        }
    }
}
