using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Killer_app.Model
{
    public class Tag
    {
        public string Naam { get; private set; }
        public string Descriptie { get; private set; }
        public List<Game> Games { get; private set; }
        public Tag(string naam, string descriptie)
        {
            Naam = naam;
            Descriptie = descriptie;
        }
        public override string ToString()
        {
            return Naam + Descriptie;
        }
    }
}
