using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Logic;
using Killer_app.Data;

namespace Killer_app.Model
{
    public class Profiel
    {
        ProfielRepository profielrepo = new ProfielRepository(new ProfielSqlContext());
 

        public string Desc { get; private set; }
        public string Naam { get; private set; }
        public byte[] Foto { get; private set; }
        public int ID { get; private set; }
        public Profiel(string naam)
        {
            Naam = naam;
        }
        public Profiel(string naam, string desc)
        {
            Naam = naam;
            Desc = desc;
        }
        public Profiel(string naam, byte[] foto)
        {
            Naam = naam;
            Foto = foto;
        }
        public Profiel(string naam, string desc, byte[] foto)
        {
            Naam = naam;
            Desc = desc;
            Foto = foto;
        }
        public bool EditProfiel(string naam, string desc, byte[] foto)
        {
            Naam = naam;
            Desc = desc;
            Foto = foto;
            return profielrepo.EditProfiel(this);
        }
        public void SetID(int id)
        {
            ID = id;
        }
        public override string ToString()
        {
            return Naam;
        }
    }
}
