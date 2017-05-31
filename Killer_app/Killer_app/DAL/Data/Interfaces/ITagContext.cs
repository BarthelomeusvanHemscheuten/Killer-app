using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Model;

namespace Killer_app.Data
{
    interface ITagContext
    {
        bool AddGame(int gameID, string tagNaam);
        bool DeleteGame(int gameID, string tagNaam);
        bool EditDescription(string tagNaam, string description);
        bool AddTag(string tagNaam, string description);
    }
}
