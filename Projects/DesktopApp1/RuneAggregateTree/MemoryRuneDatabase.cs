using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneAggregateTree
{
    class MemoryRuneDatabase : RuneTree
    {
        //Memory
        protected override Rune AddCore(Rune rune)
        {
            rune.ID = ++_nextId;
            _items.Add(Clone(rune));

            return rune;
        }

        protected void ;

        private Rune Clone(Rune rune)
        {
            var newRune = new Rune();
            Clone(newRune, rune);

            return newRune;
        }

        private void Clone(Rune target, Rune source)
        {
            target.ID = source.ID;
            target.RType = source.RType;
        }
        //list for runes

        private readonly List<Rune> _items = new List<Rune>();

        private int _nextId = 0;
    }
}
