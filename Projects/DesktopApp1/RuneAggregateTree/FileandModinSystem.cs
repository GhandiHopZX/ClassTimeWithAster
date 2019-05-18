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

        // importing the sets
        public HashSet<string> Importfunction(string path)
        {
            // string hash
            HashSet<string> NewRunesTy = new HashSet<string>();

            // if statement
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
            return NewRunesTy;
        }

        // object Rune = new RuneAggregateTree.RuneTree.Rune();
        //Taygr

        private void RuneImport()
        {
            var NewRune = new Rune();

            // Tree Type

            // You need another file path for the Rune Names

            /// This is for the rune type
            string path = @"G:\RyuuseiEngine\Assets\Mods\TaygrRuneTypes.txt";
           
            /// This is for the rune name
            string path2 = @"G:\RyuuseiEngine\Assets\Mods\TaygrRuneNames.txt";

            //// the rune types
            //Importfunction(path);

            //// the rune names
            //Importfunction(path2);

            // Addendum -> from strings to Runes

            // reference Taygr hash here

            HashSet<Rune> Taygr = new HashSet<Rune>()
            {

            };

            //do
            //{

            var StrN = new Rune();
            int FR = Importfunction(path).Count;
            string[] newRName = { };
            int[] NewRId = { };
            string[] RN = { }; 


            //names
            Importfunction(path2).CopyTo(RN);

            //types
            Importfunction(path).CopyTo(newRName);

            for (int i = 0; i < FR; i++)
            {
                // push the new rune names into whole new 
                // Runes themselves

                // Types and id
                StrN.RType = newRName[i];
                StrN.ID = NewRId[i];

                // name
                

                Rune m = new Rune {RType = newRName[i], ID = NewRId[i]};

               
                Taygr.Add(m);
            }

            return; // Return the strings here to the "RuneTree" Aggregate
        }

        
    }
}
