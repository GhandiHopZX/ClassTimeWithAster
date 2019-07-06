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
        //protected override Rune AddCore(Rune rune)
        //{
        //    rune.ID = ++_nextId;
        //    _items.Add(Clone(rune));

        //    return rune;
        //}

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

        //protected override void DeleteCore(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override Rune GetCore(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //protected override IEnumerable<Rune> GetAllCore()
        //{
        //    throw new NotImplementedException();
        //}

        //protected override Rune UpdateCore(int id, Rune newRune)
        //{
        //    throw new NotImplementedException();
        //}

        //list for runes

        private readonly List<Rune> _items = new List<Rune>();

        private int _nextId = 0;
    }
}
