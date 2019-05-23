using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static RuneAggregateTree.RuneTree;

namespace RuneAggregateTree
{
    public abstract class RuneTree
    {

        // the IRuneDatabase looks for its type names then its id
        // its type will be put under a specific branch

        // Taygr Rtype = "Stat, Ability"
        // Volmir Rtype = "Projectile, AOE"
        // Essenox Rtype = "Effects, Enchantmens"
        // Daevina Rtype = "Instantiation and Alteration"

        public struct Rune
        {
            public string RType;
            public int ID { get; set; } // dictates the name and the number
        }

        // Every New spell is a new entry in the database of spells
        // Spell Types are attributed by the types of Rune Types that
        // exist
        // the Metatron takes the Rtypes and also attributes certain
        // essences based on the Rtypes going in and the RClass
        // channels.
        public struct Spell
        {
            readonly string[] RType;
            readonly string[] RClass;
            private readonly int SID;
            readonly string Essence;
        }
        
        // Branch 1: Taygr(Ability) - Vessel Hierarchy Magick
        // This branch handles - stat buffs and ability buffs
        // Addendum -> from strings to Runes
        //public class Taygr
        //{
            public Object TaygrIn = new HashSet<Rune>();

            private void TaygrBranch()
            {
                
            }
        public Rune[] TaygrSet;


        //}

        // Branch 2: Volmir(Offensive) - Soul Hierarchy Magick
        // This branch handles - Projectile attacks and AOE attacks

        // Branch 3: Essenox(Type) - Force Hierarchy Magick
        // This branch handles - Effect types and Enchantments

        // Branch 4: Daevina(Creation) - God Hierarchy Magick
        // This branch handles - Instatiation and Alteration


        // Match tree

        //string Maintree = "root";


        public Rune Add(Rune rune)
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

        public Game Get(int id)
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be > 0.");

            return GetCore(id);
        }

        //public Game[] GetAll()
        public IEnumerable<Game> GetAll()
        {
            return GetAllCore();
        }

        public Game Update(int id, Game game)
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

        protected abstract Game GetCore(int id);

        protected abstract IEnumerable<Game> GetAllCore();

        protected abstract Game UpdateCore(int id, Game newGame);

        ~RuneTree()
        {
            // -When all runes are destroyed-
            // Ragnorok

            var Maintree = "root";
        }
        
    }
    

    

}