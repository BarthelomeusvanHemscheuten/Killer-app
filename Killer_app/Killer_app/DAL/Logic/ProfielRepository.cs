using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Data;
using Killer_app.Model;
namespace Killer_app.Logic
{
    class ProfielRepository
    {
        private IProfielContext context;

        public ProfielRepository(IProfielContext context)
        {
            this.context = context;
        }

        public bool EditProfiel(Profiel profiel)
        {
            return context.EditProfiel(profiel);
        }
        public Profiel GetProfiel(int profielID)
        {
            object[] data = context.GetProfiel(profielID);
            if (data[1] == DBNull.Value)
            {
                Profiel profiel = new Profiel((string)data[2], (byte[])data[3]);
                profiel.SetID((int)data[0]);
                return profiel;
            }
            if(data[1] == DBNull.Value && data[3] == DBNull.Value)
            {
                Profiel profiel = new Profiel((string)data[2]);
                profiel.SetID((int)data[0]);
                return profiel;
            }
            if(data[3] == DBNull.Value)
            {
                Profiel profiel = new Profiel((string)data[1], (string)data[2]);
                profiel.SetID((int)data[0]);
                return profiel;
            }
            else
            {
                Profiel profiel = new Profiel((string)data[1], (string)data[2], (byte[])data[3]);
                profiel.SetID((int)data[0]);
                return profiel;
            }
        }


    }
}
