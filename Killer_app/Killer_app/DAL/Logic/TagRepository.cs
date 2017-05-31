using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Killer_app.Data;

namespace Killer_app.Logic
{
    class TagRepository
    {
        private ITagContext context;
        public TagRepository(ITagContext context)
        {
            this.context = context;
        }
        public bool AddGame(int gameID, string tagNaam)
        {
            return context.AddGame(gameID, tagNaam);
        }
        public bool DeleteGame(int gameID, string tagNaam)
        {
            return context.DeleteGame(gameID, tagNaam);
        }
        public bool EditDescription(string tagNaam, string description)
        {
            return context.EditDescription(tagNaam, description);
        }
        public bool AddTag(string tagNaam, string description)
        {
            return context.AddTag(tagNaam, description);
        }
    }
}
