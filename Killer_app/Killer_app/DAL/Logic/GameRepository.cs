using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Data;
using Killer_app.Model;


namespace Killer_app.Logic
{
    class GameRepository
    {
        private IGameContext context;

        public GameRepository(IGameContext context)
        {
            this.context = context;
        }

        public bool Insert(Game game)
        {
            return context.Insert(game);
        }

        public bool Update(Game game)
        {
            return context.Update(game);
        }

        public bool Delete(int id)
        {
            return context.Delete(id);
        }
        public bool UpdateHours(int gameID, string userNaam, int uren)
        {
            return context.UpdateHours(gameID, userNaam, uren);
        }
        public List<Game> GetAllGames()
        {
            List<Game> games = new List<Game>();
            List<object[]> all_data = context.GetAllGames();
            foreach (object[] data in all_data)
            {
                games.Add(SetGame(data));
            }
            return games;
        }
        public List<Game> GetGamesTag(string tagnaam)
        {
            List<Game> games = new List<Game>();
            List<int> game_id = context.GetGamesIDTag(tagnaam);
            foreach (int id in game_id)
            {
                object[] data = context.GetGame(id);
                games.Add(SetGame(data));
            }
            return games;

        }
        public List<Game> SearchGames(string gamenaam)
        {
            List<Game> games = new List<Game>();
            List<object[]> all_data = context.SearchGames(gamenaam);
            foreach (object[] data in all_data)
            {
                games.Add(SetGame(data));
            }
            return games;
        }
        public Game GetGame(int gameID)
        {
            object[] data = context.GetGame(gameID);
            return SetGame(data);
        }
        //Checks data for null and calls the right constructor
        private Game SetGame(object[] data)
        {
            if (data[3] == DBNull.Value && data[5] == DBNull.Value)
            {
                Game game = new Game((string)data[1], (decimal)data[2], (decimal)data[4], (byte[])data[6]);
                game.SetID((int)data[0]);
                return game;
            }
            else if (data[3] == DBNull.Value)
            {
                Game game = new Game((string)data[1], (decimal)data[2], (decimal)data[4], (decimal)data[5], (byte[])data[6]);
                game.SetID((int)data[0]);
                return game;
            }
            else if (data[5] == DBNull.Value)
            {
                Game game = new Game((string)data[1], (decimal)data[2], (string)data[3], (decimal)data[4], (byte[])data[6]);
                game.SetID((int)data[0]);
                return game;
            }
            else
            {
                Game game = new Game((string)data[1], (decimal)data[2], (string)data[3], (decimal)data[4], (decimal)data[5], (byte[])data[6]);
                game.SetID((int)data[0]);
                return game;
            }
        }
    }
}
