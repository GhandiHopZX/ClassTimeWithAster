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

        struct Rune
        {
            string RType;
            private int ID { get; set; } // dictates the name and the number
        }

        struct Spell
        {
            string RType;
            string RClass;
            int SID;
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

            HashSet<Rune> Taygr = new HashSet<Rune>()
            {

            };

            // Imported
            HashSet<Rune> NewRunesTy = new HashSet<Rune>();

            string path = @"G:\RyuuseiEngine\Assets\Mods\TaygrRunes.txt";

            if (!File.Exists(path))
            {
                string im;
                StreamReader importRune;

                using (importRune = File.OpenText(path))
                {
                    while ((im = importRune.ReadLine()) != null)
                    {
                        Taygr.Add(im);
                    }
                }
            }


            // Branch 2: Volmir(Offensive) - Soul Hierarchy Magick
            // This branch handles - Projectile attacks and AOE attacks

            // Branch 3: Essenox(Type) - Force Hierarchy Magick
            // This branch handles - Effect types and Enchantments

            // Branch 4: Devina(Creation) - God Hierarchy Magick
            // This branch handles - Instatiation and Alteration

        }


    }
}
