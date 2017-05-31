using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Data;
using Killer_app.Logic;

namespace Killer_app.Model
{
    public class Winkelwagen
    {
        UserRepository userrepo = new UserRepository(new UserSQLContext());
        GameRepository gamerepo = new GameRepository(new GameSQLContext());
        public int ID { get; private set; }
        public decimal Prijs { get; private set; }
        public User User { get; private set; }
        public List<Game> Games { get; private set; }
        public List<Bundel> Bundels { get; private set; }

        public Winkelwagen(int winkelwagenID, string usernaam, decimal prijs)
        {
            ID = winkelwagenID;
            User = userrepo.GetUser(usernaam);
            Prijs = prijs;

        }
    }
}
