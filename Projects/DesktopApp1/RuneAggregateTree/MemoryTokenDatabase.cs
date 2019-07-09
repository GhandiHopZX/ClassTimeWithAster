using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneAggregateTree
{
    class MemoryTokenDatabase : TokenDatabase
    {
        protected override Token AddCore(Token token)
        {
            token.RTID = ++_nextId;
            _items.Add(Clone(token));

            return token;
        }

        protected override void DeleteCore(int id)
        {
            var index = GetIndex(id);
            if (index >= 0)
                _items.RemoveAt(index);
        }

        protected override IEnumerable<Token> GetAllCore()
        {
            return _items.Select(Clone);
        }

        protected override Token GetCore(int id)
        {
            var index = GetIndex(id);
            if (index >= 0)
                return Clone(_items[index]);

            return null;
        }

        protected override Token UpdateCore(int id, Token newToken)
        {
            var index = GetIndex(id);

            newToken.RTID = id;
            var existing = _items[index];
            Clone(existing, newToken);

            return newToken;
        }

        private Token Clone(Token token)
        {
            var newToken = new Token();
            Clone(newToken, token);

            return newToken;
        }

        private void Clone(Token target, Token source)
        {
            target.RTID = source.RTID;
            target.Name = source.Name;
            target.description = source.description;
            target.priceh = source.priceh;
        }

        private int GetIndex(int id)
        {
            #region Comments

            //Capturing parameters/locals needs to be done using a temp type - compiler will generate this code            
            //var tempType = new IsIdType() { Id = id };
            //var game = _items.Where(tempType.IsId).FirstOrDefault();

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
            var token = _items.Where(g => g.RTID == id).FirstOrDefault();

            //Demoing anonymous type
            //var games = from g in _items
            //            where g.Id == id
            //            select new { Id = g.Id, Name = g.Name };            
            //var game = games.FirstOrDefault();            
            if (token != null)
                return _items.IndexOf(token);

            //Forget this
            //for (var index = 0; index < _items.Count; ++index)
            //    if (_items[index]?.Id == id)
            //        return index;

            return -1;
        }

        private readonly List<Token> _items = new List<Token>();

        private int _nextId = 0;
    }
}
