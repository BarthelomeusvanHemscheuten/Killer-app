using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Logic;
using Killer_app.Data;

namespace Killer_app.Model
{
    public class Game
    {
        GameRepository gamerepo = new GameRepository(new GameSQLContext());
        public int ID { get; private set; }
        public string Naam { get; private set; }
        public decimal Prijs { get; private set; }
        public decimal OudePrijs { get; private set; }
        public decimal Score { get; private set; }
        public string Trailer { get; private set; }
        public byte[] Image { get; private set; }
        public Tag Tag { get; private set; }


        //Full game
        public Game(string naam, decimal prijs, string trailer, decimal score, decimal oudePrijs, byte[] image)
        { 
            Naam = naam;
            Prijs = prijs;
            OudePrijs = oudePrijs;
            Trailer = trailer;
            Score = score;
            Image = image;
        }
        //Game with no oudePrijs
        public Game(string naam, decimal prijs, string trailer, decimal score, byte[] image)
        {
            Naam = naam;
            Prijs = prijs;
            Trailer = trailer;
            Score = score;
            Image = image;

        }
        //Game with no trailer
        public Game(string naam, decimal prijs, decimal score, decimal oudePrijs, byte[] image)
        {
            Naam = naam;
            Prijs = prijs;
            OudePrijs = oudePrijs;
            Score = score;
            Image = image;
        }
        //Game with no trailer or Oudeprijs
        public Game(string naam, decimal prijs, decimal score, byte[] image)
        {
            Naam = naam;
            Prijs = prijs;
            Score = score;
            Image = image;
        }
        public bool EditGame(string naam, decimal prijs, string trailer, decimal score, byte[] image, decimal oudePrijs)
        {
            Naam = naam;
            Prijs = prijs;
            Trailer = trailer;
            Score = score;
            Image = image;
            OudePrijs = oudePrijs;
            return gamerepo.Update(this);
        }
        public void SetID(int id)
        {
            ID = id;
        }

        public override string ToString()
        {
            return Naam + " - " + Prijs.ToString() + "$";
        }
    }
}
