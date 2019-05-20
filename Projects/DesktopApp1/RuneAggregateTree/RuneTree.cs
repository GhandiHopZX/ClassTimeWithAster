﻿using System;
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
            public int ID { get; set; } // dictates the name and the number
        }

        public struct Spell
        {
            string RType;
            string RClass;
            private int SID;
            string Essence;
        }

        
        public class RuneTreeBranch
        {
            public List<Rune> TaygrIN = new List<Rune>();
            // Branch 1: Taygr(Ability) - Vessel Hierarchy Magick
            // This branch handles - stat buffs and ability buffs
            // Addendum -> from strings to Runes
            public class Taygr
            { 
            private void TaygrBranch()
            {

            }
              

            }

        // Branch 2: Volmir(Offensive) - Soul Hierarchy Magick
        // This branch handles - Projectile attacks and AOE attacks

        // Branch 3: Essenox(Type) - Force Hierarchy Magick
        // This branch handles - Effect types and Enchantments

        // Branch 4: Devina(Creation) - God Hierarchy Magick
        // This branch handles - Instatiation and Alteration


        // Match tree

        //string Maintree = "root";
        }

        ~ RuneTree()
        {
            // -When all runes are destroyed-
            // Ragnorok

            var Maintree = "root";
        }


    }
}

