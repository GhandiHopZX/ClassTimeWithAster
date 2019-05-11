using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            // Match tree

            // Branch 1
            
        }

        
    }
}
