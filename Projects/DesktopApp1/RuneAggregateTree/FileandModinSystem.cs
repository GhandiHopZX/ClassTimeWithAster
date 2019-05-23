using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace RuneAggregateTree
{
    class FileandModinSystem : RuneTree
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

        //Taygr 
        // reference Taygr hash here
        HashSet<Rune> Taygr = new HashSet<Rune> { }; // I still gotta pass these Runes into RuneTreeBranch's Taygr hashset
        
        // try passing the above hash to a database or better yet a tokenization
        // then send those tokens to a binding source
        // and just use the RuneTree to add categorization and description to
        // the obvious tokens(Runes) going into the form and the game

        // RuneImport >> Tokens or db >> bindingsource >> GameObject
        // >> Forms

        public HashSet<Rune> TaygrRuneImport()
        {

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
                int a = 0;
                // push the new rune names into whole new 
                // Runes themselves

                // Types and id
                StrN.RType = newRName[a];
                StrN.ID = NewRId[a];

                // name
                //TokenSystem.Names = RN[a];

                Rune m = new Rune {RType = newRName[a], ID = NewRId[a]};

                Taygr.Add(m);
                ++a;
            }
            

            return Taygr; // Return the strings here to the "RuneTree" Aggregate
        }

       
    }
}
