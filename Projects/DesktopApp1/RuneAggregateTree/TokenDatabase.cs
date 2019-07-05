using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuneAggregateTree
{
    class TokenDatabase
    {
        public Token Add(Token game)
        {
            //Validate input
            if (game == null)
                throw new ArgumentNullException(nameof(game));

            //Game must be valid            
            //new ObjectValidator().Validate(game);
            ObjectValidator.Validate(game);

            //Game names must be unique
            var existing = FindByName(game.Name);
            if (existing != null)
                throw new Exception("Game must be unique.");

            return AddCore(game);
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

        public Token Update(int id, Token game)
        {
            //Validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");
            if (game == null)
                throw new ArgumentNullException(nameof(game));

            //var val = new ObjectValidator();

            //new ObjectValidator().Validate(game);
            ObjectValidator.Validate(game);

            var existing = GetCore(id);
            if (existing == null)
                throw new Exception("Game does not exist.");

            //Game names must be unique            
            var sameName = FindByName(game.Name);
            if (sameName != null && sameName.Id != id)
                throw new Exception("Game must be unique.");

            return UpdateCore(id, game);
        }

        protected abstract Token AddCore(Token game);

        protected abstract void DeleteCore(int id);

        protected virtual Token FindByName(string name)
        {
            //LINQ
            //select
            //from
            //where
            // => IEnumerable<T>
            return (from game in GetAllCore()
                    where String.Compare(game.Name, name, true) == 0
                    //orderby game.Name, game.Id descending
                    select game).FirstOrDefault();

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

        protected abstract Token UpdateCore(int id, Token newGame);
    }
}
