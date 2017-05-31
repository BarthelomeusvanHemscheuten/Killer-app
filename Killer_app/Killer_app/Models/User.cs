using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Logic;
using Killer_app.Data;

namespace Killer_app.Model
{
    public class User
    {
        //Repo's voor de user
        UserRepository userrepo = new UserRepository(new UserSQLContext());
        ProfielRepository profielrepo = new ProfielRepository(new ProfielSqlContext());
        GameRepository gamerepo = new GameRepository(new GameSQLContext());
        LijstRepository lijstrepo = new LijstRepository(new LijstSQLContext());
        ReviewRepository reviewrepo = new ReviewRepository(new ReviewSQLContext());
        //Attributen
        private List<Game> games;
        private Profiel profiel;
        private Winkelwagen winkelwagen;
        private Verlanglijst verlanglijst;
        //Properties
        public string Usernaam { get; private set; }
        public string Wachtwoord { get; private set; }
        public bool IsAdmin { get; private set; }
        public List<Game> Games
        {
            get
            {
                if (Games == null)
                {
                    games = new List<Game>();
                    foreach (int id in userrepo.GetGamesID(Usernaam))
                    {
                        games.Add(gamerepo.GetGame(id));
                    }
                }
                return games;
            }
        }
        public Profiel Profiel { get { return profiel; } }
        public Winkelwagen Winkelwagen
        {
            get
            {
                if (winkelwagen == null)
                {
                    int winkelwagen_id = lijstrepo.GetWinkelwagenIDFromUser(Usernaam);
                    winkelwagen = lijstrepo.GetWinkelwagen(winkelwagen_id);
                }
                return winkelwagen;
            }
        }
        public Verlanglijst Verlanglijst
        {
            get
            {
                if (verlanglijst == null)
                {
                    int verlanglijst_id = lijstrepo.GetVerlanglijstIDFromUser(Usernaam);
                    verlanglijst = lijstrepo.GetVerlanglijst(verlanglijst_id);
                }
                return verlanglijst;
            }
        }

        public User(string username, int profielid, string wachtwoord, bool isAdmin)
        {
            Usernaam = username;
            Wachtwoord = wachtwoord;
            IsAdmin = isAdmin;
            profiel = profielrepo.GetProfiel(profielid);
        }
        public bool AddtoVerlanglijst(Game game)
        {
            if (game != null)
            {
                verlanglijst.Games.Add(game);
                return lijstrepo.AddGameVerlanglijst(game.ID, verlanglijst.ID);
            }
            return false;
        }
        public bool AddtoWinkelWagen(Game game)
        {
            if (game != null)
            {
                winkelwagen.Games.Add(game);
                return lijstrepo.AddGameWinkelwagen(game.ID, verlanglijst.ID);
            }
            return false;
        }
        public bool CheckOut()
        {
            try
            {
                int winkelwagen_id = lijstrepo.GetWinkelwagenIDFromUser(Usernaam);
                List<int> game_id = lijstrepo.GetGamesIDWinkelwagen(winkelwagen_id);
                foreach (int id in game_id)
                {
                    games.Add(gamerepo.GetGame(id));
                    userrepo.InsertGame(Usernaam, id);
                    lijstrepo.DeleteAllGamesWinkelwagen(winkelwagen_id);
                    lijstrepo.UpdatePriceWinkelwagen(0, winkelwagen_id);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<Game> SearchGames(string gamenaam)
        {
            if (gamenaam != null)
            {
                return gamerepo.SearchGames(gamenaam);
            }
            return null;
        }
        public bool AddHours(int uren, Game game)
        {
            if (game != null)
            {
                return gamerepo.UpdateHours(game.ID, Usernaam, uren);
            }
            return false;
        }
        public bool WriteReview(Review review)
        {
            if (review != null)
            {
                return reviewrepo.WriteReview(review.User.Usernaam, review.Game.ID, review.Titel, review.Descriptie, review.Beoordeeling, review.Afbeelding);
            }
            return false;
        }
        public bool EditProfiel(Profiel profiel)
        {
            if(profiel != null)
            {
                profielrepo.EditProfiel(profiel);
            }
            return false;
        }

        public override string ToString()
        {
            return Usernaam;
        }

    }
}
