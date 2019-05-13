using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace RuneAggregateTree
{
    public class RuneTree
    {

        public struct Rune
        {
            public string RType;
            private int ID { get; set; } // dictates the name and the number
        }

        public struct Spell
        {
            string RType;
            string RClass;
            private int SID;
            string Essence;
        }

        private RuneTree (Rune runeType, Rune runeID)
        {
            var NewRune = new Rune();


            // Tree Type

            // Match tree

            var Maintree = "root";

            // Branch 1: Taygr(Ability) - Vessel Hierarchy Magick
            // This branch handles - stat buffs and ability buffs
            
            // Imported -> from file to strings
            HashSet<string> NewRunesTy = new HashSet<string>();

            string path = @"G:\RyuuseiEngine\Assets\Mods\TaygrRunes.txt";

            if (!File.Exists(path))
            {
                string im;
                StreamReader importRune;

                using (importRune = File.OpenText(path))
                {
                    while ((im = importRune.ReadLine()) != null)
                    {
                        NewRunesTy.Add(im);
                    }
                }
            }

            // Addendum -> from strings to Runes
            HashSet<Rune> Taygr = new HashSet<Rune>()
            {

            };

            //do
            //{
                var StrN = new Rune();
                int FR = NewRunesTy.Count;
                string[] newRName = { };

                NewRunesTy.CopyTo(newRName);
                for (int i = 0; i < FR; i++)
                {
                    
                }

                //StrN += NewRunesTy; this is the goal 
                //NewRunesTy ;

            //    break;

            //} while (NewRunesTy.Count > 0);
            //{
            //}

            

            // Branch 2: Volmir(Offensive) - Soul Hierarchy Magick
            // This branch handles - Projectile attacks and AOE attacks

            // Branch 3: Essenox(Type) - Force Hierarchy Magick
            // This branch handles - Effect types and Enchantments

            // Branch 4: Devina(Creation) - God Hierarchy Magick
            // This branch handles - Instatiation and Alteration

        }

        
    }
}
