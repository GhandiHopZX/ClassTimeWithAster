using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneAggregateTree
{
    class Metatron : RuneTree
    {
        public Metatron Table()
        {
            // for now this is like this but later 
            // I want to make a table where the 
            // Metatron makes up different Runes 
            // and sets up the RClass for the spells.
            // the runes rtypes will influence.
            // the essense for the spell creation.
            // The Rune branch will also influence the 
            // hierarchy of the Rclass on the Metatron.

            throw new NotImplementedException();
        }

        protected override Rune AddCore(Rune rune)
        {
            throw new NotImplementedException();
        }

        protected override void DeleteCore(int id)
        {
            throw new NotImplementedException();
        }

        protected override IEnumerable<Rune> GetAllCore()
        {
            throw new NotImplementedException();
        }

        protected override Rune GetCore(int id)
        {
            throw new NotImplementedException();
        }

        protected override Rune UpdateCore(int id, Rune newRune)
        {
            throw new NotImplementedException();
        }
    }
}
