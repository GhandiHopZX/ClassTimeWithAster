﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using static RuneAggregateTree.RuneTree;

namespace RuneAggregateTree
{
    class FileandModinSystem
    {
        // object Rune = new RuneAggregateTree.RuneTree.Rune();
        //Taygr

        private void RuneImport()
        {
            var NewRune = new Rune();

            // Tree Type


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

            // reference Taygr hash here

            //do
            //{
            var StrN = new Rune();
            int FR = NewRunesTy.Count;
            string[] newRName = { };

            NewRunesTy.CopyTo(newRName);

            for (int i = 0; i < FR; i++)
            {
                // push the new rune names into whole new 
                // Runes themselves
                
            }

            //StrN += NewRunesTy; this is the goal 
            //NewRunesTy ;

            //    break;

            //} while (NewRunesTy.Count > 0);
            //{
            //}
            return ; // Return the strings here to the "RuneTree" Aggregate
        }
    }
}