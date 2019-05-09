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
            string Type; // dictates the type of Rune it is 
            private int ID; // dictates the name and the number
        }

        struct Spell
        {
            string RType;
            string RClass;
            int SID;
            string Essence;
        }
    }
}
