using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RuneAggregateTree
{
    public abstract class RuneTree : IRuneDatabase
    {

        // the IRuneDatabase looks for its type names then its id
        // its type will be put under a specific branch

        // Taygr Rtype = "Stat, Ability"
        // Volmir Rtype = "Projectile, AOE"
        // Essenox Rtype = "Effects, Enchantmens"
        // Daevina Rtype = "Instantiation and Alteration"

        // a single rune...
        public struct Rune
        {
            [Required(AllowEmptyStrings = false)]
            public string Name
            {
                get => _name ?? "";
                set => _name = value ?? "";
            }
            public string RType;
            private string _name;
            private string description;

            public decimal Price { get; set; }

            [Range(0, Double.MaxValue, ErrorMessage = "Price must be >= 0.")]
            public string Description
            {
                get => description ?? "";
                set => description = value;
            }

            public int ID { get; set; } // dictates the name and the number

            public override string ToString() => Name;
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
            private string Description;
        }

        // Branch 1: Taygr(Ability) - Vessel Hierarchy Magick
        // This branch handles - stat buffs and ability buffs
        // Addendum -> from strings to Runes
        //public class Taygr
        //{
        public HashSet<Rune> TaygrIn { get /*=> RuneAggregateTree.*/; }

        private void TaygrBranch()
        {

        }

        public Rune Add(Rune rune)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public Rune Get(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rune> GetAll()
        {
            throw new NotImplementedException();
        }

        public Rune Update(int id, Rune rune)
        {
            throw new NotImplementedException();
        }
        ////validation
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var items = new List<ValidationResult>();

        //    ////Name is required
        //    //if (String.IsNullOrEmpty(Name))
        //    //    items.Add(new ValidationResult("Name is required.", new[] { nameof(Name) }));


        //    //if (Price < 1000)
        //    //    items.Add(new ValidationResult("Price must be >= 0.", new[] { nameof(Price) }));

        //    //if (Price < 0)
        //    //    items.Add(new ValidationResult("Price must be >= 0.", new[] { nameof(Price) }));

        //    //if (Price > 1000)
        //    //    items.Add(new ValidationResult("Price is too great", new[] { nameof(Price) }));

        //    return items;
        //}

        //public object Yggdrasill { get; private set; }


        //}

        // Branch 2: Volmir(Offensive) - Soul Hierarchy Magick
        // This branch handles - Projectile attacks and AOE attacks

        // Branch 3: Essenox(Type) - Force Hierarchy Magick
        // This branch handles - Effect types and Enchantments

        // Branch 4: Daevina(Creation) - God Hierarchy Magick
        // This branch handles - Instatiation and Alteration


        // Match tree

        //string Maintree = "root";

        // -When all runes are destroyed-
        // Ragnorok
        public bool doa = false;
        //dead = true
        //or
        //alive = false
        private int mana = 1000000;
        private int Manaintake = 0;

        ~RuneTree()
        {
            
        }

        #region
        
        #endregion

    }




}