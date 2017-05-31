using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Killer_app.Model
{
    public class Bundel
    {
        public decimal Price { get; private set; }
        public string Code { get; private set; }
        public string Naam { get; private set; }
        public List<Game> Games { get; private set; }
        public Bundel(decimal price, string code, string naam)
        {
            Price = price;
            Code = code;
            Naam = naam;
        }
    }
}
