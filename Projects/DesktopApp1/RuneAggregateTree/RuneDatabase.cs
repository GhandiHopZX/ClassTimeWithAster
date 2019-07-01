using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RuneAggregateTree.RuneTree;

namespace RuneAggregateTree
{
    public abstract class RuneDatabase : IRuneDatabase
    {
        public Rune Add(Rune rune)
        {
            ////Validate input
            //if (rune == null)
            //    throw new ArgumentNullException(nameof(rune));

            ////Game must be valid            
            ////new ObjectValidator().Validate(game);
            //ObjectValidator.Validate(rune);

            ////Rune names must be unique
            //var existing = FindByName(rune.Name);
            //if (existing != null)
            //    throw new Exception("Rune must be unique.");

            return AddCore(rune);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            DeleteCore(id);
        }

        public Rune Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);
        }

        //public Game[] GetAll()
        public IEnumerable<Rune> GetAll()
        {
            return GetAllCore();
        }

        public Rune Update(int id, Rune rune)
        {
            //Validate
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");
            //var val = new ObjectValidator();

            ////new ObjectValidator().Validate(game);
            //ObjectValidator.Validate(rune);

            //var existing = GetCore(id);
            //if (existing == null)
            //    throw new Exception("what rune?");

            ////Game names must be unique            
            //var sameName = FindByName(rune.Name);
            //if (sameName != null && sameName.ID != id)
            //    throw new Exception("Rune must be unique.");

            return UpdateCore(id, rune);
        }

        protected abstract Rune AddCore(Rune rune);

        protected abstract void DeleteCore(int id);

        protected virtual Rune FindByName(string name)
        {
            //LINQ
            //select
            //from
            //where
            // => IEnumerable<T>
            return (from rune in GetAllCore()
                    where String.Compare(rune.Name, name, true) == 0
                    //orderby game.Name, game.Id descending
                    select rune).FirstOrDefault();

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

        protected abstract Rune GetCore(int id);

        protected abstract IEnumerable<Rune> GetAllCore();

        protected abstract Rune UpdateCore(int id, Rune newRune);
    }
}
