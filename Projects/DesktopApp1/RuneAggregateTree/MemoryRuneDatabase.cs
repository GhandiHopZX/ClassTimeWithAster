﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RuneAggregateTree.RuneTree;

namespace RuneAggregateTree
{
    class MemoryRuneDatabase : RuneDatabase
    {
        //Memory
        protected override Rune AddCore(Rune rune)
        {
            rune.ID = ++_nextId;
            _items.Add(Clone(rune));

            return rune;
        }

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
            target.Description = source.Description;
            target.Price = source.Price;
            target.Name = source.Name;
        }

        protected override void DeleteCore(int id)
        {
            var index = GetIndex(id);
            if (index >= 0)
                _items.RemoveAt(index);
        }

        protected override Rune GetCore(int id)
        {
            
            var index = GetIndex(id);
            var rtm = Clone(_items[index]);
            if (index >= 0)
                return rtm;

            return rtm;
        }

        protected override IEnumerable<Rune> GetAllCore()
        {
            return _items.Select(Clone);
        }

        protected override Rune UpdateCore(int id, Rune newRune)
        {
            var index = GetIndex(id);

            newRune.ID = id;
            var existing = _items[index];
            Clone(existing, newRune);
                return newRune;
        }

        //list for runes

        private int GetIndex(int id)
        {
            #region Comments

            //Capturing parameters/locals needs to be done using a temp type - compiler will generate this code            
            //var tempType = new IsIdType() { Id = id }; 


            //Can use lambda anywhere you need a function object, must be explicit on type
            //Func<Game, bool> isId = (g) => g.Id == id;

            //Capture problems
            //var games = _items.Where(g => g.Id == id);
            //foreach (var game in games)
            //{
            //    ++id;
            //};
            #endregion

            //_items = all games
            // .Where = filters down to only those matching IsId
            // .FirstOrDefault = returns first of filtered items, if any
            var rune = _items.Where(g => g.ID == id).FirstOrDefault();

            //Demoing anonymous type
            //var games = from g in _items
            //            where g.Id == id
            //            select new { Id = g.Id, Name = g.Name };            
            //var game = games.FirstOrDefault();            
            if (rune.Name != null && rune.RType != null)
                return _items.IndexOf(rune);

            //Forget this
            //for (var index = 0; index < _items.Count; ++index)
            //    if (_items[index]?.Id == id)
            //        return index;

            return -1;
        }

        private readonly List<Rune> _items = new List<Rune>();

        private int _nextId = 0;
    }
}
