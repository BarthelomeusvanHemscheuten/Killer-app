using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Logic;
using Killer_app.Data;

namespace Killer_app.Model
{
    public class Review
    {
        UserRepository userrepo = new UserRepository(new UserSQLContext());
        GameRepository gamerepo = new GameRepository(new GameSQLContext());
        public int ID { get; private set; }
        public string Titel { get; private set; }
        public string Descriptie { get; private set; }
        public string Afbeelding { get; private set; }
        public int Beoordeeling { get; private set; }
        public User User { get; private set; }
        public Game Game { get; private set; }

        public Review(int id, string usernaam, int gameid, string descriptie, int beoordeeling, string afbeelding, string titel)
        {
            ID = id;
            Titel = titel;
            Descriptie = descriptie;
            Beoordeeling = beoordeeling;
            Afbeelding = afbeelding;
            User = userrepo.GetUser(usernaam);
            Game = gamerepo.GetGame(gameid);
        }
        public override string ToString()
        {
            return Titel + Beoordeeling;
        }

    }
}
