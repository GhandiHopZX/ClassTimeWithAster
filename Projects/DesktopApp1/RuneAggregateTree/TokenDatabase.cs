using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneAggregateTree
{
    public abstract class TokenDatabase : ITokenDatabase
    {
        public Token Add(Token token)
        {
            //Validate input
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            //Game must be valid            
            //new ObjectValidator().Validate(game);
            ObjectValidator.Validate(token);

            //Game names must be unique
            var existing = FindByName(token.Name);
            if (existing != null)
                throw new Exception("Game must be unique.");

            return AddCore(token);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            DeleteCore(id);
        }

        public Token Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);
        }

        //public Game[] GetAll()
        public IEnumerable<Token> GetAll()
        {
            return GetAllCore();
        }

        public Token Update(int id, Token token)
        {
            //Validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");
            if (token == null)
                throw new ArgumentNullException(nameof(token));

            //var val = new ObjectValidator();

            //new ObjectValidator().Validate(game);
            ObjectValidator.Validate(token);

            var existing = GetCore(id);
            if (existing == null)
                throw new Exception("Game does not exist.");

            //Game names must be unique            
            var sameName = FindByName(token.Name);
            if (sameName != null && sameName.RTID != id)
                throw new Exception("Game must be unique.");

            return UpdateCore(id, token);
        }

        protected abstract Token AddCore(Token token);

        protected abstract void DeleteCore(int id);

        protected virtual Token FindByName(string name)
        {
            //LINQ
            //select
            //from
            //where
            // => IEnumerable<T>
            return (from token in GetAllCore()
                    where String.Compare(token.Name, name, true) == 0
                    //orderby game.Name, game.Id descending
                    select token).FirstOrDefault();

            //Extension method equivalent
            //return GetAllCore().Where(game => String.Compare(game.Name, name, true) == 0)
            //            .Select(game => game)
            //            .FirstOrDefault();

            //foreach (var game in GetAllCore())
            //{
            //    if (String.Compare(game.Name, name, true) == 0)
            //        return game;
            //};

            //return null;
        }

        protected abstract Token GetCore(int id);

        protected abstract IEnumerable<Token> GetAllCore();

        protected abstract Token UpdateCore(int id, Token newToken);
    }
}
