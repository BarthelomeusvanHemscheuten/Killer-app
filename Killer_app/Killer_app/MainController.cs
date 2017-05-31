using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Killer_app.Model;
using Killer_app.Data;
using Killer_app.Logic;

namespace Killer_app
{
    public class MainController
    {
        GameRepository gamerepo = new GameRepository(new GameSQLContext());
        UserRepository userrepo = new UserRepository(new UserSQLContext());
        ProfielRepository profielrepo = new ProfielRepository(new ProfielSqlContext());
        TagRepository tagrepo = new TagRepository(new TagSQLContext());
        ReviewRepository reviewrepo = new ReviewRepository(new ReviewSQLContext());
        LijstRepository lijstrepo = new LijstRepository(new LijstSQLContext());

        public List<Game> GetAllGames()
        {
            return gamerepo.GetAllGames();
        }
        public Game GetGame(int id)
        {
            return gamerepo.GetGame(id);
        }
        public bool InsertGame(Game game)
        {
            return gamerepo.Insert(game);
        }
        public bool DeleteGame(int id)
        {
            return gamerepo.Delete(id);
        }
        public List<Review> GetAllReviews()
        {
            return reviewrepo.GetAllReviews();
        }
        public User GetUser(string usernaam)
        {
            return userrepo.GetUser(usernaam);
        }
        public Profiel GetProfiel(int id)
        {
            return profielrepo.GetProfiel(id);
        }

    }
}