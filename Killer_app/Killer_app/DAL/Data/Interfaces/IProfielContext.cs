using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Model;

namespace Killer_app.Data
{
    interface IProfielContext
    {
        bool EditProfiel(Profiel profiel);
        object[] GetProfiel(int profielID);




    }
}
